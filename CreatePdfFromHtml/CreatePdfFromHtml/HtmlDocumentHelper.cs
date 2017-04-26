using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using HtmlAgilityPack;


namespace CreatePdfFromHtml
{
    public class HtmlDocumentHelper
    {
        private readonly HtmlDocument _document;

        public HtmlDocumentHelper(string contentHtml)
        {
            _document = new HtmlDocument();
            _document.LoadHtml(contentHtml);
        }

        public string GetContentById(string id)
        {
            var note = _document.GetElementbyId(id);
            if (note != null)
                return note.InnerHtml;
            return string.Empty;
        }

        public string RemoveContentById(string id)
        {
            var note = _document.DocumentNode.SelectSingleNode("//div[@id='" + id + "']");
            if (note != null)
                note.ParentNode.RemoveChild(note);
            return _document.DocumentNode.InnerHtml;
        }

        public string MergeUrlOnImage(string url)
        {
            var notes = _document.DocumentNode.SelectNodes("//img");
            if (notes != null && notes.Count > 0)
            {
                foreach (var note in notes)
                {
                    if (note.Attributes["src"] != null &&
                        !note.Attributes["src"].Value.Contains("data:image/png;base64"))
                    {
                        note.Attributes["src"].Value = url + note.Attributes["src"].Value;
                    }
                }
            }
            return _document.DocumentNode.InnerHtml;
        }

        public static HtmlNodeCollection BuildTableRow<T>(List<T> data, List<string> header, List<string> headerKey)
        {
            HtmlTable ht = new HtmlTable();
            if (headerKey.Count == 0)
            {
                HtmlTableRow htColumnsRow = new HtmlTableRow();
                if (header.Count == 0)
                {
                    var first = data.FirstOrDefault();
                    if (first != null)
                    {
                        first.GetType().GetProperties().Select(prop =>
                        {
                            HtmlTableCell htCell = new HtmlTableCell();
                            var attributes = prop.GetCustomAttributes(typeof (DescriptionAttribute), true);
                            if (attributes.Any())
                            {
                                var description = (DescriptionAttribute) attributes[0];
                                htCell.InnerText = description.Description;
                            }
                            else
                            {
                                htCell.InnerText = prop.Name;
                            }
                            htCell.Align = "Center";
                            htCell.Attributes.Add("style", " font-weight:bold");

                            return htCell;
                        }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
                    }
                }
                else
                {
                    header.Select(prop =>
                    {
                        HtmlTableCell htCell = new HtmlTableCell();
                        htCell.InnerText = prop;
                        htCell.Align = "Center";
                        htCell.Attributes.Add("style", "width:500px; font-weight:bold");
                        //htCell.Style = "font-size:15px";
                        return htCell;
                    }).ToList().ForEach(cell => htColumnsRow.Cells.Add(cell));
                }

                ht.Rows.Add(htColumnsRow);

                //Get the remaining rows
                data.ForEach(delegate(T obj)
                {
                    HtmlTableRow htRow = new HtmlTableRow();
                    obj.GetType().GetProperties().ToList().ForEach(delegate(PropertyInfo prop)
                    {
                        HtmlTableCell htCell = new HtmlTableCell();
                        var val = prop.GetValue(obj, null);
                        htCell.InnerText = val != null ? val.ToString() : "";
                        htRow.Cells.Add(htCell);
                    });
                    ht.Rows.Add(htRow);
                });
            }
            else
            {
                int i = 0;
                data.ForEach(delegate(T obj)
                {
                    HtmlTableRow htRow = new HtmlTableRow();
                    htRow.Attributes.Add("class", i++%2 == 1 ? "odd" : "even");
                    foreach (var item in headerKey)
                    {
                        HtmlTableCell htCell = new HtmlTableCell
                        {
                            InnerText = GetPropertyValue(obj, item)
                        };
                        htRow.Cells.Add(htCell);
                    }
                    ht.Rows.Add(htRow);
                });
            }
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            ht.RenderControl(htw);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htw.InnerWriter.ToString());
            HtmlNode tableNode = htmlDoc.DocumentNode.SelectSingleNode("//table");
            return tableNode.ChildNodes;
        }

        public static string GetPropertyValue(object car, string propertyName)
        {
            var prop = car.GetType().GetProperty(propertyName);
            if (prop == null) return "";
            var val = prop.GetValue(car);
            return val != null ? val.ToString() : "";
        }
    }
}
