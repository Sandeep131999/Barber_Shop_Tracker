using System.Xml;
using System.Xml.XPath;

namespace backend.Configuration;

/// <summary>
/// Utility class for reading SQL queries from XML files.
/// </summary>
public static class SqlQueryReader
{
    private static readonly Dictionary<string, XmlDocument> _xmlDocuments = new();

    /// <summary>
    /// 
    /// Loads and caches XML documents containing SQL queries.
    /// </summary>
    /// <param name="xmlFilePath">Path to the XML file containing queries</param>
    public static void LoadQueries(string xmlFilePath)
    {
        if (_xmlDocuments.ContainsKey(xmlFilePath))
            return;

        var document = new XmlDocument();
        document.Load(xmlFilePath);
        _xmlDocuments[xmlFilePath] = document;
    }

    /// <summary>
    /// Gets a SQL query by its ID from a loaded XML file.
    /// </summary>
    /// <param name="xmlFilePath">Path to the XML file</param>
    /// <param name="queryId">The ID of the query to retrieve</param>
    /// <returns>The SQL query string</returns>
    /// <exception cref="ArgumentException">When query is not found or XML file is not loaded</exception>
    public static string GetQuery(string xmlFilePath, string queryId)
    {
        if (!_xmlDocuments.ContainsKey(xmlFilePath))
        {
            LoadQueries(xmlFilePath);
        }

        var document = _xmlDocuments[xmlFilePath];
        var node = document.SelectSingleNode($"/queries/query[@id='{queryId}']/sql");
        
        if (node == null)
        {
            throw new ArgumentException($"Query with ID '{queryId}' not found in {xmlFilePath}");
        }

        return node.InnerText.Trim();
    }
}
