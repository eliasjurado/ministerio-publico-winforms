using System;
using System.Configuration;

//Para usar data
using System.Data;

//para usar iTextSharp
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

//para abrir y cerrar archivos

namespace appInvestigacionPreliminar.DAO
{
    public class ModeloDAO
    {

        //DAOs
        private DAO.FiscalDAO fiscal = new FiscalDAO();
        private DAO.CarpetaDAO carpeta = new CarpetaDAO();
        private DAO.SujetoProcesalDAO sujeto = new SujetoProcesalDAO();
        private DAO.DelitoDAO delito = new DelitoDAO();
        private DAO.DisposicionDAO disposicion = new DisposicionDAO();
        private DAO.RequerimientoDAO requerimiento = new RequerimientoDAO();
        private DAO.AnioDAO anio = new AnioDAO();
        private DAO.DependenciaDAO dependencia = new DependenciaDAO();
        private Conv conversion = new Conv();
        
        public string CrearDisposicionApertura(string NroCarpeta, string NroDisposicion,DateTime fecEmision) 
        {
            DataTable dtb = fiscal.ListarFiscal();
            DataRow row = dtb.Rows[0];
            string Nombre = row[1].ToString();
            string Siglas = row[2].ToString();
            string Celular = row[3].ToString();
            string Email = row[4].ToString();
            string CasillaElectronica = row[5].ToString();
            string DistritoFiscal = row[6].ToString();
            string Fiscalia = row[7].ToString();
            string Modulo = row[8].ToString();
            string Despacho = row[9].ToString();
            string Abreviatura = row[10].ToString();
            string Direccion = row[11].ToString();

            DataTable dtb1 = carpeta.ListarXNroCarpeta(NroCarpeta);
            DataRow row1 = dtb1.Rows[0];
            string DepOrigen = row1[5].ToString();
            string Sede = row1[7].ToString();
            string Caso = row1[1].ToString();
            string Oficio = row1[6].ToString();
            string DepDestino = row1[8].ToString(); ;
            string DiasInvestigacion = row1[12].ToString(); ;

            DataTable dtb2 = sujeto.ListarImputadoXID(NroCarpeta);
            string imputados="";
            foreach(DataRow imputado in dtb2.Rows)
            {
             imputados+=imputado[2].ToString()+"\n  ";
            }
            string imputadostxt="";
            foreach(DataRow imputado in dtb2.Rows)
            {
             imputadostxt+=imputado[2].ToString()+", ";
            }

            DataTable dtb3 = delito.ListarDelitoXID(NroCarpeta);
            string delitos = "";
            foreach (DataRow delit in dtb3.Rows)
            {
                delitos += delit[3].ToString() + " - " + delit[4].ToString() + "\n  ";
            }
            //delit[2]=articulo , delit[3]=generico , delit[4]=subgenerico , delit[5]=especifico , delit[6]=inciso, delit[7]=cita
            string delitostxt="";
            foreach(DataRow delit in dtb3.Rows)
            {
                delitostxt += "Delito "+delit[3].ToString() + " - " + delit[4].ToString() + " (Artículo " + delit[2].ToString() + "° del Código Penal), ";
            }

            DataTable dtb4 = sujeto.ListarAgraviadoXID(NroCarpeta);
            string agraviados = "";
            foreach (DataRow agraviado in dtb4.Rows)
            {
                agraviados += agraviado[2].ToString() + "\n  ";
            }
            string agraviadostxt="";
            foreach(DataRow agraviado in dtb4.Rows)
            {
             agraviadostxt+=agraviado[2].ToString()+", ";
            }

            DataTable dtb5 = disposicion.ListarParte1XIDyDisposicion(NroCarpeta,NroDisposicion);
            DataTable dtb6 = disposicion.ListarParte2XIDyDisposicion(NroCarpeta,NroDisposicion);
            
            DataTable dtb7 = sujeto.ListarDenuncianteXID(NroCarpeta);
            string denunciante="";
            if (dtb7.Rows.Count > 0) 
            {
                DataRow denuncia = dtb7.Rows[0];
                string denunciante1 = denuncia[2].ToString();
                denunciante = "formulada por " + denunciante1 + ", ";
            }
            else 
            {
                denunciante += ""; 
            }
            //------------------------------------------------------------------------------

            string mensaje = string.Empty;
            //Probando iTextSharp
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 80, 70, 60, 60);

            var directorio = ConfigurationManager.AppSettings.Get("DirectorioPdf");
            var directoryinfo = new DirectoryInfo(directorio);
            if (!directoryinfo.Exists)
            {
                Directory.CreateDirectory(directorio);
            }
            var nombreArchivo = NroCarpeta + "_" + NroDisposicion + ".pdf";
            var fullPath = directorio + nombreArchivo;

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(fullPath, FileMode.Create));
            doc.Open();
            //------------------------------------------------------------------------------
            //Comienza Redaccion


            //Definiendo Fuentes
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font cuerpo = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font cuerponegrita = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font cuerpoitalica = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font encabezado = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.NORMAL);  
            iTextSharp.text.Font encabezadonegrita = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.BOLD);        
            iTextSharp.text.Font titulo = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            
            //Logo
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("logofiscalia.png");
            img.ScalePercent(80f);
            doc.Add(img);

            //Encabezado
            Paragraph e1 = new Paragraph(new Chunk("DISTRITO FISCAL DE "+DistritoFiscal.ToUpper(),encabezadonegrita));
            e1.IndentationLeft = 68f;
            doc.Add(e1);
            Paragraph e2 = new Paragraph(new Chunk(Fiscalia.ToUpper() + " DE " + Modulo.ToUpper(), encabezadonegrita));
            e2.IndentationLeft = 68f;
            doc.Add(e2);
            Paragraph e3 = new Paragraph(new Chunk(Despacho.ToUpper(), encabezadonegrita));
            e3.IndentationLeft = 68f;
            doc.Add(e3);
            //---------------------------------------------------------------------------------------
            Paragraph espacio = new Paragraph(new Chunk(" ", cuerpo));
            doc.Add(espacio);
            //---------------------------------------------------------------------------------------
            
            //Sumilla

            PdfPTable sumilla = new PdfPTable(2);
            sumilla.DefaultCell.Border = Rectangle.NO_BORDER;
            sumilla.HorizontalAlignment = 0;
            sumilla.TotalWidth = 462f;
            sumilla.LockedWidth = true;
            float[] widthsumilla = new float[] { 100f, 362f };
            sumilla.SetWidths(widthsumilla);

            //Formato del texto
            Paragraph contenidosum;
            PdfPCell celdasum;
            //-----

            contenidosum = new Paragraph("Fiscal Responsable", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + Nombre, cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Carpeta Fiscal", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + Caso, cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Investigado(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + imputados.Remove(imputados.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Delito(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + delitos.Remove(delitos.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Agraviado(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + agraviados.Remove(agraviados.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            doc.Add(sumilla);
            doc.Add(espacio);

            //Titulo
            Paragraph lead = new Paragraph(new Chunk("DISPOSICIÓN DE INICIO DE INVESTIGACIÓN PRELIMINAR", titulo));
            lead.Alignment = Element.ALIGN_CENTER;
            doc.Add(lead);
            Paragraph lead1 = new Paragraph(new Chunk("N° 0"+NroDisposicion+"-"+fecEmision.Year+"-"+Abreviatura, titulo));
            lead1.Alignment = Element.ALIGN_CENTER;
            doc.Add(lead1);
            doc.Add(espacio);

            //Lugar y Fecha
            doc.Add(new Chunk(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Modulo.ToLower()) + ", " + fecEmision.ToString("dd") + " de " + fecEmision.ToString("MMMM") + " de " + fecEmision.ToString("yyyy"), cuerpo));
            doc.Add(espacio);

            //Tabla de Texto
            PdfPTable texto = new PdfPTable(2);
            texto.DefaultCell.Border = Rectangle.NO_BORDER;
            texto.HorizontalAlignment = 0;
            texto.TotalWidth = 462f;
            texto.LockedWidth = true;
            float[] widthstexto = new float[] { 30f, 432f };
            texto.SetWidths(widthstexto);

            //Formato del texto
            Paragraph contenido;
            PdfPCell celda;       
            //Vistos SubTitulo
            //-----


            contenido = new Paragraph("I.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("VISTOS:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("El Oficio No. " + Oficio + ", remitido por la " + DepOrigen.ToUpper() + ", conteniendo la denuncia " + denunciante + "contra " + imputadostxt.Remove(imputadostxt.Length - 1, 1) + " por la comisión del " + delitostxt.Remove(delitostxt.Length - 1, 1) + " en agravio de " + agraviadostxt.Remove(agraviadostxt.Length - 2, 2) + "; y,", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("II.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("CONSIDERANDO:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("2.1.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("HECHO OBJETO DE IMPUTACIÓN:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA CONSIDERANDO --

            foreach (DataRow considerando in dtb5.Rows)
            {
                contenido = new Paragraph("2.1." + considerando[2] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph(""+considerando[3]+"", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("2.2.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("ADECUACIÓN AL NCPP:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("2.2.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("El nuevo Código Procesal Penal establece en su artículo VII del título preliminar que la “Ley procesal es de aplicación inmediata, incluso al proceso en trámite, y es la que rige al tiempo de la actuación procesal” de modo que la presente ley resulta aplicable para efectos de la calificación de la presente investigación, conforme al artículo 334º y 335º del NCPP.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("2.2.2.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("En tal sentido siendo el estado de la presente, el de adecuarse al nuevo sistema procesal penal y una vez adecuado esta Fiscalía Provincial Penal Corporativa de Los Olivos, debe esclarecer el desarrollo de los hechos en función a la nueva norma adjetiva, ello con el propósito de calificar correctamente la denuncia y resolver con arreglo a ley.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("2.3.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("DE LA CALIFICACIÓN JURÍDICA:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //LOOP PARA LOS DELITOS
            //delit[2]=articulo , delit[3]=generico , delit[4]=subgenerico , delit[5]=especifico , delit[6]=cita

            //-- LOOP PARA DELITOS --

            foreach (DataRow delit in dtb3.Rows)
            {
                contenido = new Paragraph("2.3." + delit[1] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("Se le imputa a " + imputadostxt.Remove(imputadostxt.Length - 2, 2) + ", haber incurrido en la Comisión del Delito " + delit[3] + " –" + delit[4] + "– previsto por el artículo " + delit[2] + "º, inciso " + delit[6] + " del Código Penal, que señala:", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph(" ", cuerpoitalica);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph(""+delit[7]+"", cuerpoitalica);
                contenido.IndentationLeft = 32f;
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------


            contenido = new Paragraph("III.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("DE LA FUNCIÓN DEL MINISTERIO DE PÚBLICO:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("3.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("El Ministerio Público de conformidad con lo señalado en el artículo 158º de la Constitución Política del Estado, es un Órgano Constitucional Autónomo; y, el artículo 159º le ha otorgado, la titularidad de la acción penal, la defensa de la legalidad y de los intereses públicos tutelados por el derecho; y, representa en estos procesos a la sociedad.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("3.2.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Según lo dispuesto por el artículo 14° de Ley Orgánica del Ministerio Público –Decreto Legislativo Nº 052– y el artículo IV del Título Preliminar del Código Procesal Penal, a los fiscales les corresponde investigar los hechos constitutivos del delito y aportar la carga de la prueba, que determinen y acrediten la responsabilidad o inocencia del imputado.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("IV.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("DE LAS DILIGENCIAS PRELIMINARES:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("El artículo VII del Título Preliminar del Código Procesal Penal Vigente establece que: “La Ley Procesal Penal es de aplicación inmediata, incluso al proceso en trámite, y es la que rige al tiempo de la actuación procesal”; asimismo, el Artículo 65º inciso 2, del Código Procesal Penal, establece que el Fiscal, en cuanto tenga noticia del delito, realizará si correspondiere las primeras Diligencias Preliminares.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.2.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("En ese sentido, de conformidad a lo señalado por el numeral 2 del artículo 330° del NCPP , es pertinente precisar que las diligencias preliminares tienen por objeto desarrollar una actividad de investigación que permita obtener los elementos de convicción.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.3.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Si el Fiscal advierte, de estas diligencias preliminares, la existencia de indicios reveladores de la existencia de un delito, que se ha individualizado al presunto responsable, que la acción penal no ha prescrito, y que, se ha satisfecho los requisitos de procedibilidad formalizará y continuará con la Investigación Preparatoria, conforme prescribe el inciso 1 del artículo 334º del Código Procesal Penal vigente.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("V.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("DEL PLAZO DE LAS DILIGENCIAS PRELIMINARES:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("5.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Conforme al inciso 2) del Artículo 334° del Código Procesal Penal , establece: “el plazo de las diligencias preliminares es de sesenta días salvo que se produzca detención de una persona. No obstante, a ello, el Fiscal podrá fijar un plazo distinto de acuerdo a las características y circunstancias objeto de la investigación”.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("5.2.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Este despacho Fiscal es de considerar que, a efectos de realizar diligencias necesarias para el mejor esclarecimiento de los hechos, el plazo razonable para la duración de la investigación preliminar debe ser de "+DiasInvestigacion+" días.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("VI.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("DECISIÓN:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Por las razones antes expuestas, Este Ministerio Público de conformidad con lo establecido en el inciso 1 del Título Preliminar, Inciso 1 del artículo 329º, inciso 1 y 2 del artículo 330º del Código Procesal Penal y con las atribuciones que le confiere el inciso 4 del artículo 159º de la Constitución Política del Perú, en concordancia con el artículo 1º y 5º de la Ley Orgánica del Ministerio Público - Decreto Legislativo Nº 052;", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("DISPONE:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("6.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("ABRIR DILIGENCIAS PRELIMINARES EN SEDE "+Sede+" por el término de sesenta días en la investigación seguida contra " + imputadostxt.Remove(imputadostxt.Length - 2, 2) + ", presunto(s) responsable(s) de la comisión del "+delitostxt.Remove(delitostxt.Length - 2, 2)+" - en agravio de "+agraviadostxt.Remove(agraviadostxt.Length - 2, 2)+".", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("6.2.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Delegar a "+DepDestino+" la presente investigación que deberá desarrollarlo en el término de "+DiasInvestigacion+" días, para que desarrolle las siguientes diligencias:", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA DISPONE --

            foreach (DataRow dispone in dtb6.Rows)
            {
                contenido = new Paragraph("6.2." + dispone[2] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + dispone[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph(" ", encabezado);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", encabezado);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);
            
            
            contenido = new Paragraph(Siglas, encabezado);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", encabezado);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            doc.Add(texto);

            doc.Close();
            //-------------------
            mensaje = "Disposicion creada";
            return mensaje;
        }

            // LECCIONES APRENDIDAS DE ITEXTSHARP

            ////Para que itextsharp obedezca el formato que le estoy dando a paragraph tengo que crear una PdPCell y allí darle AddElement() de ese modo obvia el formato de la tabla y reconoce el formato del paragraph
            //PdfPTable probando = new PdfPTable(2);
            //probando.DefaultCell.Border = Rectangle.NO_BORDER;
            //probando.HorizontalAlignment = 0;
            //probando.TotalWidth = 462f;
            //probando.LockedWidth = true;
            //float[] widthsp = new float[] { 30f, 432f };
            //probando.SetWidths(widthsp);

            //Paragraph probando1 = new Paragraph(new Chunk("El nuevo Código Procesal Penal establece en su artículo VII del título preliminar que la “Ley procesal es de aplicación inmediata, incluso al proceso en trámite, y es la que rige al tiempo de la actuación procesal” de modo que la presente ley resulta aplicable para efectos de la calificación de la presente investigación, conforme al artículo 334º y 335º del NCPP.", cuerpo));
            //probando1.Alignment = Element.ALIGN_JUSTIFIED;

            //PdfPCell celda = new PdfPCell();
            //celda.AddElement(probando1);
            //celda.Border = Rectangle.NO_BORDER;

            //probando.AddCell(new Paragraph("2.2.", cuerpo));
            //probando.AddCell(celda);

            //doc.Add(probando);

            ////Creando párrafo
            //Paragraph parrafo = new Paragraph(new Chunk("But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?", cuerpo));

            ////Alineando el párrafo
            //parrafo.Alignment = Element.ALIGN_JUSTIFIED;
            ////Interlineado
            //parrafo.SetLeading(2,4);

            ////Agregando el párrafo al documento
            //doc.Add(parrafo);
            //doc.Add(espacio);
            //doc.Add(parrafo);

            ////Lista con guiones
            //List list = new List(List.ORDERED);
            //list.IndentationLeft=30f;
            //list.Add(new ListItem("One"));
            //list.Add("Two");
            //list.Add("Three");
            //list.Add("Four");
            //list.Add("Five");
            //doc.Add(list);

            ////Lista con numeros romanos en mayusculas (false= mayusculas, true = minusculas)
            //RomanList rlist = new RomanList(false,20);
            //rlist.IndentationLeft = 30f;
            //rlist.Add(new ListItem("One"));
            //rlist.Add("Two");
            //rlist.Add("Three");
            //rlist.Add("Four");
            //rlist.Add("Five");
            //doc.Add(rlist);


            ////Lista que contiene otra lista
            //RomanList romanlist = new RomanList(true, 20);
            //romanlist.IndentationLeft = 30f;
            //romanlist.Add("One");
            //romanlist.Add("Two");
            //romanlist.Add("Three");
            //romanlist.Add("Four");
            //romanlist.Add("Five");

            ////el 40f dentro del contructor del List es para separar el simbolo del texto y el Indentationleft es para del borde de pagina hacia el simbolo
            //List list2 = new List(List.ORDERED, 40f);
            //list2.SetListSymbol("\u2022");
            //list2.IndentationLeft = 40f;
            //list2.Add("ONE");
            //list2.Add("TWO");
            //list2.Add("THREE");
            //list2.Add(romanlist);
            //list2.Add("FOUR");
            //list2.Add("FIVE");
            //doc.Add(list2);


            ////sublist
            //List listaprueba = new List(List.ORDERED);
            //listaprueba.PreSymbol = string.Format("2.1.");
            //listaprueba.Add("Something else here");
            //listaprueba.Add("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum");
            //doc.Add(listaprueba);



        public string CrearOficioApertura(string NroCarpeta, string NroDisposicion, DateTime fecEmision) 
        {
            DataTable dtb = fiscal.ListarFiscal();
            DataRow row = dtb.Rows[0];
            string Nombre = row[1].ToString();
            string Siglas = row[2].ToString();
            string Celular = row[3].ToString();
            string Email = row[4].ToString();
            string CasillaElectronica = row[5].ToString();
            string DistritoFiscal = row[6].ToString();
            string Fiscalia = row[7].ToString();
            string Modulo = row[8].ToString();
            string Despacho = row[9].ToString();
            string Abreviatura = row[10].ToString();
            string Direccion = row[11].ToString();

            DataTable dtba = anio.ListarAnio();
            string ani = "";
            foreach (DataRow des in dtba.Rows)
            {
                if (des[0].ToString() == fecEmision.Year.ToString())
                {
                    ani = des[1].ToString();
                }
            }

            DataTable dtb1 = carpeta.ListarXNroCarpeta(NroCarpeta);
            DataRow row1 = dtb1.Rows[0];
            string DepOrigen = row1[5].ToString();
            string Carpeta = row1[0].ToString();
            string Caso = row1[1].ToString();
            string Oficio = row1[6].ToString();
            string DepDestino = row1[8].ToString(); ;
            string DiasInvestigacion = row1[12].ToString();

            string numenlet = conversion.enletras(DiasInvestigacion.ToString());

            DataTable dtbb = dependencia.ListarDependencia();
            string direcciondep = "";
            foreach (DataRow depe in dtbb.Rows)
            {
                if (depe[1].ToString() == DepDestino)
                { 
                    direcciondep = depe[2].ToString();
                }
            }

            DataTable dtb2 = sujeto.ListarImputadoXID(NroCarpeta);
            string imputados = "";
            foreach (DataRow imputado in dtb2.Rows)
            {
                imputados += imputado[2].ToString() + "\n  ";
            }
            string imputadostxt = "";
            foreach (DataRow imputado in dtb2.Rows)
            {
                imputadostxt += imputado[2].ToString() + ", ";
            }

            DataTable dtb3 = delito.ListarDelitoXID(NroCarpeta);
            string delitos = "";
            foreach (DataRow delit in dtb3.Rows)
            {
                delitos += delit[3].ToString() + " - " + delit[4].ToString() + "\n  ";
            }
            //delit[2]=articulo , delit[3]=generico , delit[4]=subgenerico , delit[5]=especifico , delit[6]=cita
            string delitostxt = "";
            foreach (DataRow delit in dtb3.Rows)
            {
                delitostxt += "delito " + delit[3].ToString().ToUpper() + " en la modalidad de " + delit[4].ToString().ToUpper() + " " + delit[5].ToString().ToUpper() + ", ";
            }

            DataTable dtb4 = sujeto.ListarAgraviadoXID(NroCarpeta);
            string agraviados = "";
            foreach (DataRow agraviado in dtb4.Rows)
            {
                agraviados += agraviado[2].ToString() + "\n  ";
            }
            string agraviadostxt = "";
            foreach (DataRow agraviado in dtb4.Rows)
            {
                agraviadostxt += agraviado[2].ToString() + ", ";
            }

            //------------------------------------------------------------------------------

            string mensaje = string.Empty;
            //Probando iTextSharp
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 80, 70, 60, 60);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C://Roma/Oficio"
                + NroCarpeta + "_" + NroDisposicion + ".pdf", FileMode.Create));
            doc.Open();
            //------------------------------------------------------------------------------
            //Comienza Redaccion


            //Definiendo Fuentes
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font cuerpo = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font cuerponegrita = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font cuerpoitalica = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font encabezado = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font encabezadonegrita = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font titulo = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);

            //Año Oficial
            Paragraph a = new Paragraph("\"" + ani.ToUpper() + "\"", cuerponegrita);
            a.Alignment = Element.ALIGN_CENTER;
            doc.Add(a);

            //Logo
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("logofiscalia.png");
            img.ScalePercent(80f);
            doc.Add(img);

            //Encabezado
            Paragraph e1 = new Paragraph("DISTRITO FISCAL DE " + DistritoFiscal.ToUpper(), encabezadonegrita);
            e1.IndentationLeft = 68f;
            doc.Add(e1);
            Paragraph e2 = new Paragraph(Fiscalia.ToUpper() + " DE " + Modulo.ToUpper(), encabezadonegrita);
            e2.IndentationLeft = 68f;
            doc.Add(e2);
            Paragraph e3 = new Paragraph(Despacho.ToUpper(), encabezadonegrita);
            e3.IndentationLeft = 68f;
            doc.Add(e3);
            //---------------------------------------------------------------------------------------
            Paragraph espacio = new Paragraph(" ", cuerpo);
            doc.Add(espacio);

            doc.Add(new Chunk(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Modulo.ToLower()) + ", " + fecEmision.ToString("dd") + " de " + fecEmision.ToString("MMMM") + " de " + fecEmision.ToString("yyyy"), cuerpo));
            doc.Add(espacio);
            doc.Add(new Paragraph("OFICIO N° ___-" + fecEmision.Year + "-" + Abreviatura, cuerponegrita));
            doc.Add(espacio);
            doc.Add(new Paragraph("Señor",cuerponegrita));
            doc.Add(new Paragraph("Jefe de " + DepDestino, cuerponegrita));
            doc.Add(new Paragraph(direcciondep, cuerponegrita));
            doc.Add(espacio);
            doc.Add(new Paragraph("Presente", cuerponegrita));
            doc.Add(espacio);
            
            Chunk c1 = new Chunk("Asunto: ", cuerponegrita);
            Chunk c2 = new Chunk("El que se indica.", cuerpo);
            Paragraph aa = new Paragraph();
            aa.AddSpecial(c1);
            aa.AddSpecial(c2);
            doc.Add(aa);

            c1 = new Chunk("Referencia: ", cuerponegrita);
            c2 = new Chunk("Caso N° "+Caso, cuerpo);
            aa = new Paragraph();
            aa.AddSpecial(c1);
            aa.AddSpecial(c2);
            doc.Add(aa);
            doc.Add(espacio);

            Paragraph p1 = new Paragraph("Tengo el agrado de dirigirme a usted, a fin de REMITIRLE el original de la Carpeta Fiscal N° " + Carpeta + " a pp. ___, a efectos de que en el plazo de "+numenlet.ToUpper()+" (" + DiasInvestigacion + ") DÍAS HÁBILES, cumpla con realizar los actos de investigación dispuestos por este Despacho, conforme a la Disposición N° 01 que se adjunta a la presente. Debiendo devolver la carpeta en el plazo establecido, BAJO RESPONSABILIDAD FUNCIONAL, que en caso de incumplimiento se informará a inspectoría de la PNP.", cuerpo);
            p1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(p1);
            doc.Add(espacio);

            p1 = new Paragraph("En la investigación seguida contra " + imputadostxt.Remove(imputadostxt.Length - 1, 1).ToUpper() + " por la presunta comisión del " + delitostxt.Remove(delitostxt.Length - 1, 1) + " en agravio de " + agraviadostxt.Remove(agraviadostxt.Length - 2, 2).ToUpper() + ".", cuerpo);
            p1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(p1);
            doc.Add(espacio);

            p1 = new Paragraph("Sin otro particular, aprovecho la oportunidad para expresarle los sentimientos de mi consideración y estima personal.", cuerpo);
            p1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(p1);
            doc.Add(espacio);

            p1 = new Paragraph("Atentamente,", cuerpo);
            p1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(p1);
            doc.Add(espacio);

            p1 = new Paragraph(Siglas, cuerpo);
            p1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(p1);
            doc.Add(espacio);

            doc.Close();
            //-------------------
            mensaje = "Oficio creado";
            return mensaje;
        }

        public string CrearAbstencionIncoacion(string NroCarpeta, string NroDisposicion,DateTime fecEmision,string Actuados)
        {
            DataTable dtb = fiscal.ListarFiscal();
            DataRow row = dtb.Rows[0];
            string Nombre = row[1].ToString();
            string Siglas = row[2].ToString();
            string Celular = row[3].ToString();
            string Email = row[4].ToString();
            string CasillaElectronica = row[5].ToString();
            string DistritoFiscal = row[6].ToString();
            string Fiscalia = row[7].ToString();
            string Modulo = row[8].ToString();
            string Despacho = row[9].ToString();
            string Abreviatura = row[10].ToString();
            string Direccion = row[11].ToString();

            DataTable dtb1 = carpeta.ListarXNroCarpeta(NroCarpeta);
            DataRow row1 = dtb1.Rows[0];
            string DepOrigen = row1[5].ToString();
            string Sede = row1[7].ToString();
            string Carpeta = row1[0].ToString();
            string Caso = row1[1].ToString();
            string Oficio = row1[6].ToString();
            string DepDestino = row1[8].ToString(); ;
            string DiasInvestigacion = row1[12].ToString(); ;

            DataTable dtb2 = sujeto.ListarImputadoXID(NroCarpeta);
            string imputados = "";
            foreach (DataRow imputado in dtb2.Rows)
            {
                imputados += imputado[2].ToString() + "\n  ";
            }
            string imputadostxt = "";
            foreach (DataRow imputado in dtb2.Rows)
            {
                imputadostxt += imputado[2].ToString() + ", ";
            }

            DataTable dtb3 = delito.ListarDelitoXID(NroCarpeta);
            string delitos = "";
            foreach (DataRow delit in dtb3.Rows)
            {
                delitos += delit[4].ToString() + " " + delit[5].ToString() + "\n  ";
            }
            //delit[2]=articulo , delit[3]=generico , delit[4]=subgenerico , delit[5]=especifico , delit[6]=inciso, delit[7]=cita
            string delitostxt = "";
            foreach (DataRow delit in dtb3.Rows)
            {
                delitostxt += "Delito " + delit[3].ToString() + ", en la modalidad de " + delit[4].ToString().ToUpper() + " " + delit[5].ToString().ToUpper() + ", previsto en el artículo " + delit[2].ToString() + "° del Código Penal, ";
            }

            DataTable dtb4 = sujeto.ListarAgraviadoXID(NroCarpeta);
            string agraviados = "";
            foreach (DataRow agraviado in dtb4.Rows)
            {
                agraviados += agraviado[2].ToString() + "\n  ";
            }
            string agraviadostxt = "";
            foreach (DataRow agraviado in dtb4.Rows)
            {
                agraviadostxt += agraviado[2].ToString() + ", ";
            }

            DataTable dtb5 = disposicion.ListarParte1XIDyDisposicion(NroCarpeta, NroDisposicion);
            DataTable dtb6 = disposicion.ListarParte2XIDyDisposicion(NroCarpeta, NroDisposicion);
            DataTable dtb8 = disposicion.ListarParte3XIDyDisposicion(NroCarpeta, NroDisposicion);

            DataTable dtb7 = sujeto.ListarDenuncianteXID(NroCarpeta);
            string denunciante = "";
            if (dtb7.Rows.Count > 1) 
            {
                DataRow denuncia = dtb7.Rows[0];
                string denunciante1 = denuncia[2].ToString();
                denunciante = "formulada por " + denunciante1 + ", ";
            }
            else
            {
                denunciante += ""; 
            }
            //------------------------------------------------------------------------------

            string mensaje = string.Empty;
            //Probando iTextSharp
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 80, 70, 60, 60);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C://Roma/Disposicion"
                + NroCarpeta + "_" + NroDisposicion + ".pdf", FileMode.Create));
            doc.Open();
            //------------------------------------------------------------------------------
            //Comienza Redaccion


            //Definiendo Fuentes
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font cuerpo = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font cuerponegrita = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font cuerpoitalica = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font encabezado = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font encabezadonegrita = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font titulo = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);

            //Logo
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("logofiscalia.png");
            img.ScalePercent(80f);
            doc.Add(img);

            //Encabezado
            Paragraph e1 = new Paragraph(new Chunk("DISTRITO FISCAL DE " + DistritoFiscal.ToUpper(), encabezadonegrita));
            e1.IndentationLeft = 68f;
            doc.Add(e1);
            Paragraph e2 = new Paragraph(new Chunk(Fiscalia.ToUpper() + " DE " + Modulo.ToUpper(), encabezadonegrita));
            e2.IndentationLeft = 68f;
            doc.Add(e2);
            Paragraph e3 = new Paragraph(new Chunk(Despacho.ToUpper(), encabezadonegrita));
            e3.IndentationLeft = 68f;
            doc.Add(e3);
            //---------------------------------------------------------------------------------------
            Paragraph espacio = new Paragraph(new Chunk(" ", cuerpo));
            doc.Add(espacio);
            //---------------------------------------------------------------------------------------

            //Sumilla

            PdfPTable sumilla = new PdfPTable(2);
            sumilla.DefaultCell.Border = Rectangle.NO_BORDER;
            sumilla.HorizontalAlignment = 0;
            sumilla.TotalWidth = 462f;
            sumilla.LockedWidth = true;
            float[] widthsumilla = new float[] { 100f, 362f };
            sumilla.SetWidths(widthsumilla);

            //Formato del texto
            Paragraph contenidosum;
            PdfPCell celdasum;
            //-----

            contenidosum = new Paragraph("Carpeta Fiscal", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + Caso, cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Imputado(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + imputados.Remove(imputados.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Materia(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + delitos.Remove(delitos.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Agraviado(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + agraviados.Remove(agraviados.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Sumilla", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": ABSTENCIÓN DE INCOACIÓN", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            doc.Add(sumilla);
            doc.Add(espacio);

            //Titulo
            Paragraph lead1 = new Paragraph(new Chunk("DISPOSICIÓN N° 0" + NroDisposicion + "-" + fecEmision.Year + "-" + Abreviatura, titulo));
            lead1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(lead1);
            doc.Add(espacio);

            //Lugar y Fecha
            doc.Add(new Chunk(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Modulo.ToLower()) + ", " + fecEmision.ToString("dd") + " de " + fecEmision.ToString("MMMM") + " de " + fecEmision.ToString("yyyy"), cuerpo));
            doc.Add(espacio);

            //Dando Cuenta
            Paragraph dandocuenta = new Paragraph(new Chunk("DANDO CUENTA :", titulo));
            dandocuenta.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dandocuenta);
            doc.Add(espacio);

            //Dando Cuenta Parrafo
            Paragraph dandocuentap = new Paragraph(new Chunk("El Oficio N° " + Actuados + " mediante la cual se remite los actuados en torno a la denuncia seguida en contra de " + imputadostxt.Remove(imputadostxt.Length - 1, 1) + " presunto(s) autor(es) de la comisión del " + delitostxt.Remove(delitostxt.Length - 1, 1) + " en agravio de " + agraviadostxt.Remove(agraviadostxt.Length - 1, 1) + " y;", cuerpo));
            dandocuentap.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dandocuentap);
            doc.Add(espacio);

            //Tabla de Texto
            PdfPTable texto = new PdfPTable(2);
            texto.DefaultCell.Border = Rectangle.NO_BORDER;
            texto.HorizontalAlignment = 0;
            texto.TotalWidth = 462f;
            texto.LockedWidth = true;
            float[] widthstexto = new float[] { 30f, 432f };
            texto.SetWidths(widthstexto);

            //Formato del texto
            Paragraph contenido;
            PdfPCell celda;
            //Vistos SubTitulo
            //-----


            contenido = new Paragraph("I.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("ATENDIENDO:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("1.1.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("De Los Hechos Denunciados:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA ATENDIENDO --

            foreach (DataRow atendiendo in dtb5.Rows)
            {
                contenido = new Paragraph("1.1." + atendiendo[2] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + atendiendo[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("1.2.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("CALIFICACIÓN JURÍDICA DE LOS HECHOS:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //LOOP PARA LOS DELITOS
            //delit[2]=articulo , delit[3]=generico , delit[4]=subgenerico , delit[5]=especifico , delit[6]=inciso , delit[7]=cita

            //-- LOOP PARA DELITOS --

            foreach (DataRow delit in dtb3.Rows)
            {
                contenido = new Paragraph("1.2." + delit[1] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("El tipo penal del delito de " + delit[4].ToString().ToUpper() + " " + delit[5].ToString().ToUpper() + ", previsto en el artículo " + delit[2] + "º inciso " + delit[6] + " del Código Penal, sanciona la conducta del agente que:", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph(" ", cuerpoitalica);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + delit[7] + "", cuerpoitalica);
                contenido.IndentationLeft = 32f;
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("1.3.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("JUICIO DE SUBSUNCIÓN:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA JUICIO DE SUBSUNCIÓN --

            foreach (DataRow juicio in dtb6.Rows)
            {
                contenido = new Paragraph("1.3." + juicio[2] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + juicio[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("1.4.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("DE LA ABSTENCIÓN DE LA ACCIÓN PENAL: ACUERDO REPARATORIO", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

           //-- LOOP PARA ACUERDO --

            foreach (DataRow acuerdo in dtb8.Rows)
            {
                contenido = new Paragraph("1.4." + acuerdo[2] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + acuerdo[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("1.4."+(1+dtb8.Rows.Count)+".", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("El Artículo 2º numeral 6º del Código Procesal Penal señala que procede aplicar un Acuerdo Reparatorio \"Independientemente de los casos establecidos en el numeral 1) procederá un acuerdo reparatorio en los delitos previstos y sancionados en los artículos 122, 185, 187, 189-A Primer Párrafo, 190, 191, 192, 193, 196, 197, 198, 205, 215 del Código Penal, y en los delitos culposos. No rige esta regla cuando haya pluralidad importante de víctimas o concurso con otro delito; salvo que, en este último caso, sea de menor gravedad o que afecte bienes jurídicos disponibles.\"", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("1.4." + (2 + dtb8.Rows.Count) + ".", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Agrega el Artículo 2º numeral 3º indica que \"(…) No será necesaria la referida diligencia si el imputado y la víctima llegan a un acuerdo y este consta en instrumento público o documento privado legalizado notarialmente.\"", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("1.4." + (3 + dtb8.Rows.Count) + ".", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("En este orden de ideas, atendiendo al documento antes citado, así como al precepto referido en el numeral 2º del presente considerando, corresponde disponer el archivo de la presente investigación.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Por lo que estando a las consideraciones expuestas, en uso de las facultades conferidas por Ley:", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            doc.Add(texto);
            doc.Add(espacio);

            //Dispone
            Paragraph dispone = new Paragraph(new Chunk("SE DISPONE :", titulo));
            dispone.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dispone);
            doc.Add(espacio);

            //Dando Cuenta Parrafo
            dispone = new Paragraph(new Chunk("Primero: ABSTENERSE del ejercicio de la acción penal en la investigación seguida en contra de " + imputadostxt.Remove(imputadostxt.Length - 1, 1) + " en agravio de " + agraviadostxt.Remove(agraviadostxt.Length - 1, 1) + " por la comisión del "+delitostxt.Remove(delitostxt.Length - 2, 2)+".", cuerpo));
            dispone.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dispone);
            doc.Add(espacio);

            dispone = new Paragraph(new Chunk("Segundo: La presente disposición deberá notificarse a los sujetos procesales, tal como lo dispone el inciso 1 del artículo 127° del Código Procesal Penal. Registrándose y Notificándose donde corresponda.", cuerpo));
            dispone.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dispone);

            doc.Add(espacio);
            
            dispone = new Paragraph(new Chunk(""+Siglas, encabezado));
            dispone.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dispone);

            doc.Close();
            //-------------------
            mensaje = "Disposicion creada";
            return mensaje;
        }

        public string CrearReqIncautacion(string NroCarpeta, string NroRequerimiento, DateTime fecEmision)
        {
            DataTable dtb = fiscal.ListarFiscal();
            DataRow row = dtb.Rows[0];
            string Nombre = row[1].ToString();
            string Siglas = row[2].ToString();
            string Celular = row[3].ToString();
            string Email = row[4].ToString();
            string CasillaElectronica = row[5].ToString();
            string DistritoFiscal = row[6].ToString();
            string Fiscalia = row[7].ToString();
            string Modulo = row[8].ToString();
            string Despacho = row[9].ToString();
            string Abreviatura = row[10].ToString();
            string Direccion = row[11].ToString();

            DataTable dtb1 = carpeta.ListarXNroCarpeta(NroCarpeta);
            DataRow row1 = dtb1.Rows[0];
            string DepOrigen = row1[5].ToString();
            string Sede = row1[7].ToString();
            string Carpeta = row1[0].ToString();
            string Caso = row1[1].ToString();
            string Oficio = row1[6].ToString();
            string DepDestino = row1[8].ToString(); ;
            string DiasInvestigacion = row1[12].ToString(); ;

            DataTable dtb2 = sujeto.ListarImputadoXID(NroCarpeta);
            string imputados = "";
            foreach (DataRow imputado in dtb2.Rows)
            {
                imputados += imputado[2].ToString() + "\n  ";
            }
            string imputadostxt = "";
            foreach (DataRow imputado in dtb2.Rows)
            {
                imputadostxt += imputado[2].ToString() + ", ";
            }

            DataTable dtb3 = delito.ListarDelitoXID(NroCarpeta);
            string delitos = "";
            foreach (DataRow delit in dtb3.Rows)
            {
                delitos += delit[4].ToString() + " " + delit[5].ToString() + "\n  ";
            }
            //delit[2]=articulo , delit[3]=generico , delit[4]=subgenerico , delit[5]=especifico , delit[6]=inciso, delit[7]=cita
            string delitostxt = "";
            foreach (DataRow delit in dtb3.Rows)
            {
                delitostxt += "Delito " + delit[3].ToString() + ", en la modalidad de " + delit[4].ToString().ToUpper() + " " + delit[5].ToString().ToUpper() + ", previsto en el artículo " + delit[2].ToString() + "° del Código Penal, ";
            }

            DataTable dtb4 = sujeto.ListarAgraviadoXID(NroCarpeta);
            string agraviados = "";
            foreach (DataRow agraviado in dtb4.Rows)
            {
                agraviados += agraviado[2].ToString() + "\n  ";
            }
            string agraviadostxt = "";
            foreach (DataRow agraviado in dtb4.Rows)
            {
                agraviadostxt += agraviado[2].ToString() + ", ";
            }

            DataTable dtb5 = requerimiento.ListarParte1XIDyRequerimiento(NroCarpeta, NroRequerimiento);
            DataTable dtb6 = requerimiento.ListarParte2XIDyRequerimiento(NroCarpeta, NroRequerimiento);
            DataTable dtb8 = requerimiento.ListarParte3XIDyRequerimiento(NroCarpeta, NroRequerimiento);
            DataTable dtb9 = requerimiento.ListarParte4XIDyRequerimiento(NroCarpeta, NroRequerimiento);

            DataTable dtb7 = sujeto.ListarDenuncianteXID(NroCarpeta);
            string denunciante = "";
            if (dtb7.Rows.Count > 1)
            {
                DataRow denuncia = dtb7.Rows[0];
                string denunciante1 = denuncia[2].ToString();
                denunciante = "formulada por " + denunciante1 + ", ";
            }
            else
            {
                denunciante += "";
            }
            //------------------------------------------------------------------------------

            string mensaje = string.Empty;
            //Probando iTextSharp
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 80, 70, 60, 60);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C://Roma/Disposicion"
                + NroCarpeta + "_" + NroRequerimiento + ".pdf", FileMode.Create));
            doc.Open();
            //------------------------------------------------------------------------------
            //Comienza Redaccion


            //Definiendo Fuentes
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font cuerpo = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font cuerponegrita = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font cuerpoitalica = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font encabezado = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font encabezadonegrita = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font titulo = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);

            //Logo
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("logofiscalia.png");
            img.ScalePercent(80f);
            doc.Add(img);

            //Encabezado
            Paragraph e1 = new Paragraph(new Chunk("DISTRITO FISCAL DE " + DistritoFiscal.ToUpper(), encabezadonegrita));
            e1.IndentationLeft = 68f;
            doc.Add(e1);
            Paragraph e2 = new Paragraph(new Chunk(Fiscalia.ToUpper() + " DE " + Modulo.ToUpper(), encabezadonegrita));
            e2.IndentationLeft = 68f;
            doc.Add(e2);
            Paragraph e3 = new Paragraph(new Chunk(Despacho.ToUpper(), encabezadonegrita));
            e3.IndentationLeft = 68f;
            doc.Add(e3);
            //---------------------------------------------------------------------------------------
            Paragraph espacio = new Paragraph(new Chunk(" ", cuerpo));
            doc.Add(espacio);
            //---------------------------------------------------------------------------------------

            //Sumilla

            PdfPTable sumilla = new PdfPTable(2);
            sumilla.DefaultCell.Border = Rectangle.NO_BORDER;
            sumilla.HorizontalAlignment = 0;
            sumilla.TotalWidth = 462f;
            sumilla.LockedWidth = true;
            float[] widthsumilla = new float[] { 100f, 362f };
            sumilla.SetWidths(widthsumilla);

            //Formato del texto
            Paragraph contenidosum;
            PdfPCell celdasum;
            //-----

            contenidosum = new Paragraph("Carpeta Fiscal", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + Caso, cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Imputado(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + imputados.Remove(imputados.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Materia(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + delitos.Remove(delitos.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Agraviado(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + agraviados.Remove(agraviados.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Sumilla", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": REQUERIMIENTO DE INCAUTACIÓN", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            doc.Add(sumilla);
            doc.Add(espacio);

            //Titulo
            Paragraph lead1 = new Paragraph(new Chunk("REQUERIMIENTO N° 0" + NroRequerimiento + "-" + fecEmision.Year + "-" + Abreviatura, titulo));
            lead1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(lead1);
            doc.Add(espacio);

            lead1 = new Paragraph(new Chunk("SEÑOR JUEZ DEL JUZGADO DE INVESTIGACION PREPARATORIA DE TURNO DE " + DistritoFiscal.ToUpper(), titulo));
            lead1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(lead1);
            doc.Add(espacio);

            lead1 = new Paragraph(new Chunk("" + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Nombre.ToLower()) + ", Fiscal Provincial del " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Despacho.ToLower()) + " de la " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Fiscalia.ToLower()) + " de " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Modulo.ToLower()) + " del Distrito Fiscal de " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DistritoFiscal.ToLower()) + ", con domicilio procesal en " + Direccion + ", con teléfono celular " + Celular + " con Casilla Electrónica " + CasillaElectronica + ", a Usted digo:", cuerpo));
            lead1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(lead1);
            doc.Add(espacio);

            //Tabla de Texto
            PdfPTable texto = new PdfPTable(2);
            texto.DefaultCell.Border = Rectangle.NO_BORDER;
            texto.HorizontalAlignment = 0;
            texto.TotalWidth = 462f;
            texto.LockedWidth = true;
            float[] widthstexto = new float[] { 30f, 432f };
            texto.SetWidths(widthstexto);

            //Formato del texto
            Paragraph contenido;
            PdfPCell celda;
            //Vistos SubTitulo
            //-----


            contenido = new Paragraph("I.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("REQUERIMIENTO FISCAL:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("1.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("De conformidad con lo prescrito en el inciso segundo del artículo 316º, incisos 1) y 2) del Código Procesal Penal vigente en este Distrito Judicial, SOLICITO la confirmación de la incautación de los siguientes bienes:", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA BIENES --

            foreach (DataRow bienes in dtb5.Rows)
            {
                contenido = new Paragraph("1.1." + bienes[2] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + bienes[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("II.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("HECHOS:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);
            
            contenido = new Paragraph("2.1.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("HECHOS ACONTECIDOS:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA HECHOS --

            foreach (DataRow hechos in dtb6.Rows)
            {
                contenido = new Paragraph("2.1." + hechos[2] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + hechos[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("2.2.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("ANÁLISIS DE LO ACTUADO", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("2.2.1.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("DE LOS ACTUADOS SE TIENE LOS SIGUIENTES ELEMENTOS DE CONVICCIÓN:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA ACTUADOS --

            foreach (DataRow actuados in dtb8.Rows)
            {
                contenido = new Paragraph("2.1." + actuados[2] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + actuados[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("III.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("FUNDAMENTACIÓN FÁCTICA", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA FACTICA --

            foreach (DataRow factica in dtb9.Rows)
            {
                contenido = new Paragraph("3." + factica[2] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + factica[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("3." + (dtb9.Rows.Count+1).ToString() + ".", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Respecto a los bienes incautados señalados en el punto I se solicita la confirmatoria de la incautación en la medida que los mismos han sido hallados en el registro personal del imputado.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("3." + (dtb9.Rows.Count + 2).ToString() + ".", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("En razón a ello nos encontramos dentro de la incautación instrumental, prevista en el artículo 316º, incisos 1) y 2)  del Código Procesal Penal.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);


            contenido = new Paragraph("IV.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("FUNDAMENTACIÓN JURÍDICA", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.1.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("AMPARA EL PRESENTE REQUERIMIENTO FISCAL:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.1.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("El inciso 1 y 2 del artículo 316° del Código Procesal Penal, el cual faculta al Ministerio Público a realizar la incautación durante las primeras diligencias.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.1.2.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("En el artículo 318° del Código Procesal Penal, en el cual se establece \"… La Fiscalía de la Nación dictará las disposiciones reglamentarias necesarias para garantizar la corrección y eficacia de la diligencia, así como para determinar el lugar de custodia y las reglas de administración de los bienes incautados(…)\".", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("V.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("ANEXOS:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("5.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Copia de los principales actuados de la investigación.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            doc.Add(texto);
            doc.Add(espacio);

            //Dispone
            Paragraph dispone = new Paragraph(new Chunk("POR LO EXPUESTO:", titulo));
            dispone.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dispone);
            doc.Add(espacio);

            //Dando Cuenta Parrafo
            dispone = new Paragraph(new Chunk("Solicito se declare fundado el presente requerimiento de CONFIRMACIÓN DE INCAUTACIÓN dentro del plazo de Ley.", cuerpo));
            dispone.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dispone);
            doc.Add(espacio);

            //Lugar y Fecha
            doc.Add(new Chunk(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Modulo.ToLower()) + ", " + fecEmision.ToString("dd") + " de " + fecEmision.ToString("MMMM") + " de " + fecEmision.ToString("yyyy"), cuerpo));
            doc.Add(espacio);

            doc.Add(espacio);
            doc.Add(espacio);
            doc.Add(espacio);

            //Firma
            dispone = new Paragraph(new Chunk("" + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Nombre.ToLower()), cuerponegrita));
            dispone.Alignment = Element.ALIGN_CENTER;
            doc.Add(dispone);
            dispone = new Paragraph(new Chunk("" + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Fiscalia.ToLower()), cuerponegrita));
            dispone.Alignment = Element.ALIGN_CENTER;
            doc.Add(dispone);
            dispone = new Paragraph(new Chunk("" + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Despacho.ToLower()), cuerponegrita));
            dispone.Alignment = Element.ALIGN_CENTER;
            doc.Add(dispone);

            doc.Add(espacio);

            dispone = new Paragraph(new Chunk("" + Siglas, encabezado));
            dispone.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dispone);

            doc.Close();
            //-------------------
            mensaje = "Requerimiento de incautación creado";
            return mensaje;
        }

        public string CrearReqPrisionPreventiva(string NroCarpeta, string NroRequerimiento, DateTime fecEmision,string penaMin,string penaMax,string penaReq)
        {
            DataTable dtb = fiscal.ListarFiscal();
            DataRow row = dtb.Rows[0];
            string Nombre = row[1].ToString();
            string Siglas = row[2].ToString();
            string Celular = row[3].ToString();
            string Email = row[4].ToString();
            string CasillaElectronica = row[5].ToString();
            string DistritoFiscal = row[6].ToString();
            string Fiscalia = row[7].ToString();
            string Modulo = row[8].ToString();
            string Despacho = row[9].ToString();
            string Abreviatura = row[10].ToString();
            string Direccion = row[11].ToString();

            DataTable dtb1 = carpeta.ListarXNroCarpeta(NroCarpeta);
            DataRow row1 = dtb1.Rows[0];
            string DepOrigen = row1[5].ToString();
            string Sede = row1[7].ToString();
            string Carpeta = row1[0].ToString();
            string Caso = row1[1].ToString();
            string Oficio = row1[6].ToString();
            string DepDestino = row1[8].ToString(); ;
            string DiasInvestigacion = row1[12].ToString(); ;

            DataTable dtb2 = sujeto.ListarImputadoXID(NroCarpeta);
            string imputados = "";
            foreach (DataRow imputado in dtb2.Rows)
            {
                imputados += imputado[2].ToString() + "\n  ";
            }
            string imputadostxt = "";
            foreach (DataRow imputado in dtb2.Rows)
            {
                imputadostxt += imputado[2].ToString() + ", ";
            }
            string imputadosdni = "";
            foreach (DataRow imputado in dtb2.Rows)
            {
                imputadosdni += imputado[2].ToString() + ", identificado con " + imputado[4].ToString() + " N° " + imputado[5].ToString()+", ";
            }

            DataTable dtb3 = delito.ListarDelitoXID(NroCarpeta);
            string delitos = "";
            foreach (DataRow delit in dtb3.Rows)
            {
                delitos += delit[4].ToString() + " " + delit[5].ToString() + "\n  ";
            }
            //delit[2]=articulo , delit[3]=generico , delit[4]=subgenerico , delit[5]=especifico , delit[6]=inciso, delit[7]=cita
            string delitostxt = "";
            foreach (DataRow delit in dtb3.Rows)
            {
                delitostxt += "Delito " + delit[3].ToString() + ", en la modalidad de " + delit[4].ToString().ToUpper() + " " + delit[5].ToString().ToUpper() + ", previsto en el artículo " + delit[2].ToString() + "°, inciso " + delit[6].ToString() + " del Código Penal, ";
            }

            //Agravantes
            DataTable dtb3a = delito.ListarAgravanteXID(NroCarpeta);
            string agravantestxt = "";
            if (dtb3a.Rows.Count > 0)
            {
                foreach (DataRow delit in dtb3a.Rows)
                {
                    agravantestxt += " en concordancia con el artículo " + delit[2].ToString() + "° numeral " + delit[6].ToString().ToUpper() + " del Código Penal,";
                }
            }
            else
            {
                agravantestxt = "";
            }
            

            DataTable dtb4 = sujeto.ListarAgraviadoXID(NroCarpeta);
            string agraviados = "";
            foreach (DataRow agraviado in dtb4.Rows)
            {
                agraviados += agraviado[2].ToString() + "\n  ";
            }
            string agraviadostxt = "";
            foreach (DataRow agraviado in dtb4.Rows)
            {
                agraviadostxt += agraviado[2].ToString() + ", ";
            }

            DataTable dtb5 = requerimiento.ListarParte1XIDyRequerimiento(NroCarpeta, NroRequerimiento);
            DataTable dtb6 = requerimiento.ListarParte2XIDyRequerimiento(NroCarpeta, NroRequerimiento);
            DataTable dtb8 = requerimiento.ListarParte3XIDyRequerimiento(NroCarpeta, NroRequerimiento);

            DataTable dtb7 = sujeto.ListarDenuncianteXID(NroCarpeta);
            string denunciante = "";
            if (dtb7.Rows.Count > 0)
            {
                DataRow denuncia = dtb7.Rows[0];
                string denunciante1 = denuncia[2].ToString();
                denunciante = "formulada por " + denunciante1 + ", ";
            }
            else
            {
                denunciante += "";
            }
            //------------------------------------------------------------------------------

            string mensaje = string.Empty;
            //Probando iTextSharp
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 80, 70, 60, 60);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C://Roma/Requerimiento"
                + NroCarpeta + "_" + NroRequerimiento + ".pdf", FileMode.Create));
            doc.Open();
            //------------------------------------------------------------------------------
            //Comienza Redaccion


            //Definiendo Fuentes
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font cuerpo = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font cuerponegrita = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font cuerpoitalica = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font encabezado = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font encabezadonegrita = new iTextSharp.text.Font(bf, 6, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font titulo = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);

            //Logo
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("logofiscalia.png");
            img.ScalePercent(80f);
            doc.Add(img);

            //Encabezado
            Paragraph e1 = new Paragraph(new Chunk("DISTRITO FISCAL DE " + DistritoFiscal.ToUpper(), encabezadonegrita));
            e1.IndentationLeft = 68f;
            doc.Add(e1);
            Paragraph e2 = new Paragraph(new Chunk(Fiscalia.ToUpper() + " DE " + Modulo.ToUpper(), encabezadonegrita));
            e2.IndentationLeft = 68f;
            doc.Add(e2);
            Paragraph e3 = new Paragraph(new Chunk(Despacho.ToUpper(), encabezadonegrita));
            e3.IndentationLeft = 68f;
            doc.Add(e3);
            //---------------------------------------------------------------------------------------
            Paragraph espacio = new Paragraph(new Chunk(" ", cuerpo));
            doc.Add(espacio);
            //---------------------------------------------------------------------------------------

            //Sumilla

            PdfPTable sumilla = new PdfPTable(2);
            sumilla.DefaultCell.Border = Rectangle.NO_BORDER;
            sumilla.HorizontalAlignment = 0;
            sumilla.TotalWidth = 462f;
            sumilla.LockedWidth = true;
            float[] widthsumilla = new float[] { 100f, 362f };
            sumilla.SetWidths(widthsumilla);

            //Formato del texto
            Paragraph contenidosum;
            PdfPCell celdasum;
            //-----

            contenidosum = new Paragraph("Carpeta Fiscal", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + Caso, cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Imputado(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + imputados.Remove(imputados.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Materia(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + delitos.Remove(delitos.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Agraviado(s)", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": " + agraviados.Remove(agraviados.Length - 3, 3), cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph("Sumilla", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            contenidosum = new Paragraph(": MANDATO DE PRISIÓN PREVENTIVA", cuerpo);
            contenidosum.Alignment = Element.ALIGN_JUSTIFIED;
            celdasum = new PdfPCell();
            celdasum.Border = Rectangle.NO_BORDER;
            celdasum.AddElement(contenidosum);
            sumilla.AddCell(celdasum);

            doc.Add(sumilla);
            doc.Add(espacio);

            //Titulo
            Paragraph lead1 = new Paragraph(new Chunk("REQUERIMIENTO N° 0" + NroRequerimiento + "-" + fecEmision.Year + "-" + Abreviatura, titulo));
            lead1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(lead1);
            doc.Add(espacio);
                
                
            lead1 = new Paragraph(new Chunk("SEÑOR JUEZ DEL JUZGADO DE INVESTIGACIÓN PREPARATORIA DE TURNO DE " + DistritoFiscal.ToUpper(), titulo));
            lead1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(lead1);
            doc.Add(espacio);

            //Introduccion
            lead1 = new Paragraph(new Chunk("" + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Nombre.ToLower()) + ", Fiscal Provincial del " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Despacho.ToLower()) + " de la " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Fiscalia.ToLower()) + " de " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Modulo.ToLower()) + " del Distrito Fiscal de " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DistritoFiscal.ToLower()) + ", con domicilio procesal en "+Direccion+", con teléfono celular "+Celular+" con Casilla Electrónica "+CasillaElectronica+", a Usted digo:", cuerpo));
            lead1.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(lead1);
            doc.Add(espacio);




            //Tabla de Texto
            PdfPTable texto = new PdfPTable(2);
            texto.DefaultCell.Border = Rectangle.NO_BORDER;
            texto.HorizontalAlignment = 0;
            texto.TotalWidth = 462f;
            texto.LockedWidth = true;
            float[] widthstexto = new float[] { 30f, 432f };
            texto.SetWidths(widthstexto);

            //Formato del texto
            Paragraph contenido;
            PdfPCell celda;
            //Vistos SubTitulo
            //-----


            contenido = new Paragraph("I.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("REQUERIMIENTO FISCAL:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Al amparo de lo establecido en el Artículo 268º del Código Procesal Penal, este Despacho Fiscal solicita MANDATO DE PRISIÓN PREVENTIVA de " + imputadosdni.Remove(imputadosdni.Length - 1, 1) + " por la comisión del " + delitostxt.Remove(delitostxt.Length - 1, 1) + agravantestxt+ " en agravio de " + agraviadostxt.Remove(agraviadostxt.Length - 2, 2)+".", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("II.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("HECHOS:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("2.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("De los antecedentes se tienen los hechos siguientes:", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA HECHOS --

            foreach (DataRow hechos in dtb5.Rows)
            {
                contenido = new Paragraph("2.1." + hechos[2] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + hechos[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("III.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("MODALIDAD DE DETENCIÓN:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Las circunstancias de la aprehensión y detención del imputado se dieron en flagrancia.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("IV.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("FUNDAMENTOS DEL REQUERIMIENTO DE MANDATO DE PRISIÓN PREVENTIVA:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Se da en el presente caso los elementos concurrentes para que se dicte Mandato de Prisión Preventiva, conforme a lo establecido en el artículo 268º del Código Procesal Penal, ya que de acuerdo a los primeros recaudos es posible determinar lo siguiente:", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.1.1.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("EXISTEN FUNDADOS Y GRAVES ELEMENTOS DE CONVICCIÓN PARA ESTIMAR RAZONABLEMENTE LA COMISIÓN DE UN DELITO QUE VINCULE AL IMPUTADO COMO AUTOR DEL MISMO.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Para acreditar la existencia de este punto, señor Juez, ofrecemos como elemento de prueba las siguientes diligencias:", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA ELEMENTOS DE CONVICCION --

            foreach (DataRow elementos in dtb6.Rows)
            {
                contenido = new Paragraph("4.1.1." + elementos[2] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + elementos[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("4.1.2.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("LA SANCIÓN A IMPONERSE RESULTA SUPERIOR A CUATRO AÑOS DE PENA PRIVATIVA DE LIBERTAD:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.1.2.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("El hecho investigado en contra del imputado " + imputadostxt.Remove(imputadostxt.Length - 1, 1) + " se encuentra dentro de la descripción del Delito materia de investigación, constituye " + delitostxt.Remove(delitostxt.Length - 1, 1) + " en concordancia con artículo ……. numerales ….. (describir la agravante), ……. (describir la otra agravante) y (señalar si es el primer o segundo párrafo de las agravantes.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.1.2.2.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("La pena para este delito fluctúa entre los " + penaMin + " a " + penaMax + " años de pena privativa de la libertad y por la tentativa (de ser el caso) la disminución de la pena es prudencial, siendo esta que no será menor a cuatro años.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.1.3.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("CON RELACIÓN AL PELIGRO DE FUGA Y OTRAS CIRCUNSTANCIAS DEL CASO PARTICULAR, PERMITE COLEGIR RAZONABLEMENTE QUE TRATARÁ DE ELUDIR LA ACCIÓN DE LA JUSTICIA (PELIGRO DE FUGA) U OBSTACULIZAR LA AVERIGUACIÓN DE LA VERDAD (PELIGRO DE OBSTACULIZACIÓN) .", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            //-- LOOP PARA PELIGRO --

            foreach (DataRow peligros in dtb8.Rows)
            {
                contenido = new Paragraph("4.1.3." + peligros[2] + ".", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);

                contenido = new Paragraph("" + peligros[3] + "", cuerpo);
                contenido.Alignment = Element.ALIGN_JUSTIFIED;
                celda = new PdfPCell();
                celda.Border = Rectangle.NO_BORDER;
                celda.AddElement(contenido);
                texto.AddCell(celda);
            }

            //----------------------------

            contenido = new Paragraph("4.2.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("CON RELACION AL PLAZO (DURACIÓN DE LA MEDIDA)", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.2.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Se solicita el plazo de prisión preventiva sea por " + penaReq + " meses, atendiendo a que estimamos que resulta ser un plazo razonable a fin de culminarse el proceso, teniéndose en cuenta la actuación de ulteriores actos de investigación conforme se han expuesto en la disposición de formalización de investigación preparatoria como son el realizar pericias y oficiar a diferentes instituciones.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.2.2.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("De la misma forma una vez culminado la etapa de investigación, se procederá a la conclusión de la investigación preparatoria y formular el requerimiento respectivo, para luego realizar las audiencias en etapa Intermedia y Juzgamiento, la cual podría realizarse en diferentes sesiones conforme la carga procesal del Juzgado.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.3.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("CON RELACION A LA PROPORCIONALIDAD DE LA MEDIDA", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.3.1.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Se señala que la proporcionalidad strictu sensu no busca la decisión “proporcional”, sino evitar, contrariamente, la desproporcionada. Ello implica el respeto de las exigencias de idoneidad e intervención mínima del derecho penal y que se sustentan con los elementos que la fundamentan: el “riesgo de frustración” del agraviado -que requiere justicia a través de los operadores de justicia-; y la “peligrosidad procesal” del imputado.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.3.2.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("La proporcionalidad en sentido estricto de la medida cautelar, obliga al operador jurídico penal a enfrentar diversos principios y derechos; esto es, la ponderación entre los derechos fundamentales en pugna; la libertad del imputado, el derecho del ciudadano agraviado a desenvolverse dentro de un medio social con seguridad para él y sus bienes, la vigencia de la ley penal, el respecto a los bienes jurídicos sociales, entre otras.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.3.3.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Si el dictado de la prisión preventiva supera el primer test su objeto posibilita que se cumplan con los fines constitucionalmente perseguidos por el proceso penal. En segundo nivel solamente será superado si la prisión preventiva es el medio más idóneo para asegurar que se cumpla con el proceso penal. El tercer nivel se verifica en la medida en que la prisión preventiva sea la última ratio del sistema en aquellos casos en donde es ostensible que la libertad del acusado implica un peligro procesal.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("4.3.4.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("En el presente caso consideramos que la medida cautelar que se solicita es proporcional en la medida que si bien se busca restringir la libertad del imputado ello tiene como finalidad el aseguramiento y eficacia de la acción de la justicia, así como de los fines del proceso, debiéndose considerar en este sentido que el investigado se le atribuye la comisión de " + delitostxt.Remove(delitostxt.Length - 1, 1) + " a la medida solicitada en tanto que el imputado no ha acreditado tener arraigo que permita un eficaz proceso penal instaurado en su contra, por lo que siendo ello así, estimamos que la medida solicitada es la menos gravosa posible atendiendo a los bienes en conflicto.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("V.", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("FUNDAMENTOS JURÍDICOS", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("Señor Juez, amparamos nuestra pretensión en el artículo 268º, 269º y 270º del Código Procesal Penal.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("POR TANTO:", cuerponegrita);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph(" ", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            contenido = new Paragraph("A usted señor Juez, solicito se sirva dar el trámite que corresponde al presente requerimiento, dictándose mandato de PRISIÓN PREVENTIVA contra " + imputadostxt.Remove(imputadostxt.Length - 1, 1) + " conforme a Ley.", cuerpo);
            contenido.Alignment = Element.ALIGN_JUSTIFIED;
            celda = new PdfPCell();
            celda.Border = Rectangle.NO_BORDER;
            celda.AddElement(contenido);
            texto.AddCell(celda);

            doc.Add(texto);
            doc.Add(espacio);

            //Dispone
            Paragraph dispone = new Paragraph(new Chunk("OTROSÍ DIGO: Pongo a disposición de su Despacho al detenido, para los fines correspondientes.  ", cuerpo));
            dispone.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(dispone);
            doc.Add(espacio);

            //Lugar y Fecha
            doc.Add(new Chunk(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Modulo.ToLower()) + ", " + fecEmision.ToString("dd") + " de " + fecEmision.ToString("MMMM") + " de " + fecEmision.ToString("yyyy"), cuerpo));
            doc.Add(espacio);
            
            doc.Add(espacio);
            doc.Add(espacio);
            doc.Add(espacio);

            //Firma
            dispone = new Paragraph(new Chunk("" + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Nombre.ToLower()), cuerponegrita));
            dispone.Alignment = Element.ALIGN_CENTER;
            doc.Add(dispone);
            dispone = new Paragraph(new Chunk("" + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Fiscalia.ToLower()), cuerponegrita));
            dispone.Alignment = Element.ALIGN_CENTER;
            doc.Add(dispone);
            dispone = new Paragraph(new Chunk("" + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Despacho.ToLower()), cuerponegrita));
            dispone.Alignment = Element.ALIGN_CENTER;
            doc.Add(dispone);

            doc.Close();
            //-------------------
            mensaje = "Requerimiento de prisión preventiva creado";
            return mensaje;
        }

    }
}
