using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using SGC.Auxiliares;
using SGC.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace SGC.Vista
{
    public partial class ConsultarConstancia : Window
    {
        private int _docenteId;
        private ExperienciaEducativa _experienciaEducativaSeleccionada;

        public ConsultarConstancia()
        {
            _docenteId = SesionDocente.Instance.DocenteID;
            InitializeComponent();
            CargarPeriodos(_docenteId);
        }

        private void CargarPeriodos(int docenteID)
        {
            try
            {
                using (var context = new Modelo.SistemaGeneracionConstanciasEntities())
                {
                    var periodos = context.DocenteExperienciaEducativa
                                          .Where(dee => dee.DocenteID == docenteID)
                                          .Select(dee => dee.Periodo)
                                          .Distinct()
                                          .OrderBy(periodo => periodo)
                                          .ToList();

                    PeriodosComboBox.ItemsSource = periodos;

                    if (periodos.Any())
                    {
                        PeriodosComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron periodos para este docente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los periodos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            string periodoSeleccionado = PeriodosComboBox.SelectedItem.ToString();

            int docenteID = _docenteId;

            var experienciaEducativa = ObtenerDatosExperienciaEducativa(docenteID, periodoSeleccionado);

            if (experienciaEducativa == null || experienciaEducativa.ExperienciaEducativaID == 0)
            {
                MessageBox.Show("No se encontró información para la experiencia educativa del período seleccionado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _experienciaEducativaSeleccionada = experienciaEducativa;
            DescargarButton.Visibility = Visibility.Visible;
            MessageBox.Show("Experiencia Educativa encontrada. Puede proceder con la descarga.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DescargarButton_Click(object sender, RoutedEventArgs e)
        {
            if (_experienciaEducativaSeleccionada == null)
            {
                System.Windows.MessageBox.Show("No hay una experiencia educativa seleccionada. Realice una búsqueda primero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Seleccione la carpeta donde desea guardar el PDF";
                folderBrowserDialog.ShowNewFolderButton = true;

                System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    string carpetaSeleccionada = folderBrowserDialog.SelectedPath;

                    string rutaPDF = System.IO.Path.Combine(carpetaSeleccionada, "Constancia.pdf");

                    string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    CrearConstanciaPDF(rutaPDF, _experienciaEducativaSeleccionada, fecha);

                    System.Diagnostics.Process.Start(rutaPDF);
                }
                else
                {
                    MessageBox.Show("No se seleccionó ninguna carpeta.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            var menuDocente = new MenuDocente();
            menuDocente.Show();
            this.Close();
        }

        private ExperienciaEducativa ObtenerDatosExperienciaEducativa(int docenteID, string periodo)
        {
            try
            {
                using (var context = new Modelo.SistemaGeneracionConstanciasEntities())
                {
                    var experienciaEducativaID = context.DocenteExperienciaEducativa
                        .Where(dee => dee.DocenteID == docenteID && dee.Periodo == periodo)
                        .Select(dee => dee.ExperienciaEducativaID)
                        .FirstOrDefault();

                    if (experienciaEducativaID == 0)
                    {
                        return NotFoundEE();
                    }

                    var experienciaEducativa = context.ExperienciaEducativa
                        .FirstOrDefault(ee => ee.ExperienciaEducativaID == experienciaEducativaID);

                    return experienciaEducativa ?? NotFoundEE();
                }
            }
            catch
            {
                return NotFoundEE();
            }
        }

        private ExperienciaEducativa NotFoundEE()
        {
            return new ExperienciaEducativa
            {
                ExperienciaEducativaID = 0,
                ProgramaEducativoID = 0,
                Bloque = "N/A",
                Seccion = "N/A",
                CreditosEe = 0,
                HSM = 0
            };
        }

        private void CrearConstanciaPDF(string filePath, ExperienciaEducativa experiencia, string fecha)
        {
            string profesor = $"{SesionDocente.Instance.Nombre} {SesionDocente.Instance.Apellidos}";
            string director = "Dr. Montané";
            try
            {
                if (experiencia == null || experiencia.ExperienciaEducativaID == 0)
                {
                    MessageBox.Show("No se ha seleccionado una experiencia educativa válida para generar el PDF.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Document documento = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter.GetInstance(documento, new FileStream(filePath, FileMode.Create));
                documento.Open();

                var fontTitulo = FontFactory.GetFont("HELVETICA", 12, Font.BOLD);
                var fontSubtitulo = FontFactory.GetFont("HELVETICA", 10, Font.BOLD);
                var fontTexto = FontFactory.GetFont("HELVETICA", 10);
                var fontFirma = FontFactory.GetFont("HELVETICA", 12, Font.BOLD);

                var encabezado = new Paragraph("Facultad de Estadística e Informática\nRegión Xalapa", fontTitulo)
                {
                    Alignment = Element.ALIGN_RIGHT
                };
                documento.Add(encabezado);

                documento.Add(new Paragraph("\n"));

                var titulo = new Paragraph("A quien corresponda\n\n", fontSubtitulo)
                {
                    Alignment = Element.ALIGN_LEFT
                };
                documento.Add(titulo);

                var cuerpo = new Paragraph($"El que suscribe, Director de la Facultad de Estadística e Informática, de la Universidad,\n\nHACE CONSTAR\n\n", fontTexto)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                documento.Add(cuerpo);

                var contenido = new Paragraph($"que el Mtro. {profesor}, impartió la siguiente experiencia educativa en el período {experiencia.Bloque}:\n\n", fontTexto)
                {
                    Alignment = Element.ALIGN_JUSTIFIED
                };
                documento.Add(contenido);

                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 2, 4, 2, 2 });

                tabla.AddCell(new PdfPCell(new Phrase("Programa educativo", fontSubtitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase("Experiencia educativa", fontSubtitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase("Bloque/Sección/Créditos", fontSubtitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase("H/S/M", fontSubtitulo)) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });

                tabla.AddCell(new PdfPCell(new Phrase(experiencia.ProgramaEducativoID.ToString(), fontTexto)) { HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase(experiencia.NombreEE, fontTexto)) { HorizontalAlignment = Element.ALIGN_CENTER }); // Cambiar según disponibilidad
                tabla.AddCell(new PdfPCell(new Phrase($"{experiencia.Bloque}/{experiencia.Seccion}/{experiencia.CreditosEe}", fontTexto)) { HorizontalAlignment = Element.ALIGN_CENTER });
                tabla.AddCell(new PdfPCell(new Phrase(experiencia.HSM.ToString(), fontTexto)) { HorizontalAlignment = Element.ALIGN_CENTER });

                documento.Add(tabla);

                documento.Add(new Paragraph("\n"));

                var parrafoAdicional = new Paragraph($"A petición del interesado(a) y para los fines legales que a la misma convenga, se extiende la presente en la ciudad de Xalapa-Enríquez, Veracruz a los {fecha}.\n\n", fontTexto)
                {
                    Alignment = Element.ALIGN_JUSTIFIED
                };
                documento.Add(parrafoAdicional);

                documento.Add(new Paragraph("\n\n\n\n"));
                var firma = new Paragraph($"Atentamente\n\n\"Lis de Veracruz: Arte, Ciencia, Luz\"\n\n{director}\nDirector", fontFirma)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                documento.Add(firma);

                documento.Close();

                MessageBox.Show("Constancia generada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
