using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Word;

/// <summary>
/// Summary description for EmailSignature
/// </summary>
public class EmailSignature
{


    static string baseName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\Properties\";
    public static List<ADUser> People;

    public EmailSignature()
    {
        //
        // TODO: Add constructor logic here
        //        
    }

    public static void CreateSignature(List<ADUser> People)
    {

        object missing = Missing.Value;
        object bkmark = "\\endofdoc";

        Application winword = new Application();

        foreach (ADUser person in People)
        {
            Document signature = new Document();


            signature.Content.SetRange(0, 0);



            string logo = baseName + "NAL Logo.png";


            Table tbl = signature.Tables.Add(signature.Range(), 1, 2, null, true);
            tbl.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);

            foreach (Row row in tbl.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    if (cell.RowIndex == 1)
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.Range.InlineShapes.AddPicture(logo, true, false);
                        }
                        if (cell.ColumnIndex == 2)
                        {
                            cell.Range.ParagraphFormat.SpaceAfter = 0.7f;
                            cell.Range.Font.Name = "Cambria";


                            Paragraph p2 = cell.Range.Paragraphs.Add();
                            Range tRange2 = p2.Range;



                            Paragraph information = cell.Range.Paragraphs.Add();
                            Paragraph link = p2.Range.Paragraphs.Add();



                            object webAddress = "https://www.nalenders.com";
                            object linkShown = "NALenders.com";
                            object oRange = link.Range;
                            tRange2 = link.Range.Hyperlinks.Add(tRange2, ref webAddress, ref missing, ref missing, ref linkShown, ref missing).Range;
                            object anchor = "NALenders.com";
                            string info = person.Name + "\r" + person.Title + "\r" + "Tel: " + person.Telephone + "\r\n" + person.Address + " | " + person.City + ", " + person.State + " " + person.PostalCode + " | ";
                            cell.Range.InsertBefore(info);

                        }
                    }
                    else
                    {
                        cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                    }
                }
            }



            foreach (InlineShape image in signature.InlineShapes)
            {
                try
                {
                    image.LinkFormat.SavePictureWithDocument = true;
                }
                catch (Exception ex)
                {

                }
            }

            //Save the document
            //object filename = @"C:\\Users\Jerrell.nal\\Desktop\\New Signatures\\" + person.Name.ToString() +"\\" + person.Name.ToString() + " signature.rtf";
            //signature.SaveAs2(ref filename);
            //signature.Close();
            //signature = null;

            object html = @"C:\\Users\Jerrell.nal\\Desktop\\New Signatures\\" + person.Name.ToString() + "\\" + person.Name.ToString() + " signature.htm";
            object htmDocFormat = WdSaveFormat.wdFormatHTML;
            signature.SaveAs2(ref html, ref htmDocFormat);
            signature.Close();
            signature = null;
        }

        winword.Quit();
        winword = null;

        //System.Windows.Forms.MessageBox.Show("Documents created successfully !");

    }
}