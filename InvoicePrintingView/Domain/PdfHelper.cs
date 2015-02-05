using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;

namespace InvoiceViewModel
{
    class PdfHelper
    {
        

        public static void InsertarHeader()
        {

            var datos = MySqlHelper.GetAllProducts().Tables["dataGridProducts"];

            int numFilas   =  datos.Rows.Count;
            int numColumns = datos.Columns.Count;
            string valor_cell = "--";
            

            string PDF_NAME = "REPORTE.pdf";
            Document doc;
            PdfWriter wri;

            doc = new Document(iTextSharp.text.PageSize.A4, 1, 1, 42, 35);
            wri = PdfWriter.GetInstance(doc, new FileStream(PDF_NAME, FileMode.Create));

            doc.Open();

            Image header = Image.GetInstance("Header2.PNG");
            header.ScalePercent(50,70);
            doc.Add(header);
                                            
            PdfPTable table = new PdfPTable(numColumns);
            table.TotalWidth = 700; //iTextSharp.text.PageSize.A4.Width;

            //relative col widths in proportions 
            float[] widths = new float[] { 6f, 1f,1f ,1f};
            table.SetWidths(widths);

         /*   PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));

          * 
          * 
            cell.Colspan = numColumns;
            cell.HorizontalAlignment =0; //0=Left, 1=Centre, 2=Right
            cell.VerticalAlignment = 0;
            cell.BackgroundColor = new BaseColor(50, 240, 70);
            table.AddCell(cell);      */
            
            //Common configurations
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, true);
            Font times = new Font(bfTimes, 12, Font.BOLD, BaseColor.WHITE);

            //Insert Headers (Name of columns)

            PdfPCell cel = new PdfPCell();
            cel.BackgroundColor = new BaseColor(15, 168, 250);
          //  cel.PaddingLeft = 20f;
            foreach (DataColumn column in datos.Columns)
            {  
                valor_cell = column.ColumnName;
                cel.Phrase = new Phrase(valor_cell, times);
                cel.BorderWidthLeft = Rectangle.NO_BORDER;
                cel.BorderWidthBottom = Rectangle.NO_BORDER;
               // cel.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //cel.BorderWidthRight= Rectangle.NO_BORDER;
                table.AddCell(cel);
            }

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, true);
            Font time = new Font(bf, 8, Font.NORMAL, BaseColor.BLACK);
            PdfPCell cell2 = new PdfPCell();
            for (int i = -0; i < numFilas; i++)
                for (int k = -0; k < numColumns; k++)
                {  
                    valor_cell = datos.Rows[i][k].ToString();
                    cell2.Phrase = new Phrase(valor_cell, time);
                    cell2.BorderWidthLeft = Rectangle.NO_BORDER;
                   cell2.BorderWidthRight = Rectangle.NO_BORDER;
                   cell2.BorderWidthBottom = Rectangle.NO_BORDER;

                    if (k == 0)
                    {
                        cell2.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    }else
                        cell2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                   
                  
                   
                   //
                   table.AddCell(cell2);
                }

          //  table.AddCell("Col 1 Row 1");
          //  table.AddCell("Col 2 Row 1");
          //  table.AddCell("Col 3 Row 1");
          //  table.AddCell("Col 1 Row 2");
          //  table.AddCell("Col 2 Row 2");
         //   table.AddCell("Col 3 Row 2");


          



            doc.Add(table);

            

          //  Image header = Image.GetInstance("header.png");
         //   doc.Add(header);
        //    iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph("This is my fiest and \n second line sabado.");

        //    doc.Add(paragraph);

            doc.Close();
        }
    }
}
