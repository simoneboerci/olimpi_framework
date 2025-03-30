using Logging.Core.Enums;
using Logging.Core.Interfaces;
using Logging.Core.Models;
using Logging.Data.Providers;
using Moq;

namespace Logging.Test
{
    [TestClass]
    public class FileLogProviderTest
    {
        // Genera un percorso unico nella cartella temporanea
        private static string GetTempFilePath(string extension = ".log")
        {
            return Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + extension);
        }

        /// <summary>
        /// Verifica che, con la rotazione disabilitata, DisplayLogEntry
        /// scriva il testo formattato direttamente nel file specificato.
        /// </summary>
        [TestMethod]
        public void DisplayLogEntry_ShouldAppendFormattedTextToFile_NonRotated()
        {
            // Arrange
            string tempFile = GetTempFilePath();
            var fakeFormatter = new Mock<ILogFormatter>();
            fakeFormatter.Setup(f => f.Format(It.IsAny<LogEntry>()))
                         .Returns<LogEntry>(entry => "TestFormatted: " + entry.Message);
            
            // Creiamo il provider senza abilitare la rotazione
            var provider = new FileLogProvider(fakeFormatter.Object, tempFile, rotateFiles: false);
            var logEntry = new LogEntry(LogLevel.Info, "NonRotated test", DateTime.Now.ToString("o"));

            // Act
            provider.DisplayLogEntry(logEntry);

            // Assert: il contenuto del file deve contenere il testo formattato
            string content = File.ReadAllText(tempFile);
            Assert.IsTrue(content.Contains("TestFormatted: NonRotated test"), "Il file di log non contiene il messaggio atteso.");

            // Cleanup
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }

        /// <summary>
        /// Verifica che, con la rotazione abilitata, 
        /// venga creato un file il cui nome contiene il suffisso basato sulla data corrente
        /// e che al suo interno venga scritto il log formattato.
        /// </summary>
        [TestMethod]
        public void DisplayLogEntry_ShouldAppendFormattedTextToRotatedFile()
        {
            // Arrange
            string baseFilePath = GetTempFilePath();
            var fakeFormatter = new Mock<ILogFormatter>();
            fakeFormatter.Setup(f => f.Format(It.IsAny<LogEntry>()))
                         .Returns<LogEntry>(entry => "Rotated: " + entry.Message);
            
            // Creiamo il provider con la rotazione abilitata
            var provider = new FileLogProvider(fakeFormatter.Object, baseFilePath, rotateFiles: true);
            var logEntry = new LogEntry(LogLevel.Error, "Rotated test", DateTime.Now.ToString("o"));

            // Il file di log ruotato usa un suffisso con la data corrente (formato "yyyyMMdd")
            string expectedFile = Path.Combine(
                Path.GetDirectoryName(baseFilePath)!,
                $"{Path.GetFileNameWithoutExtension(baseFilePath)}_{DateTime.Now.ToString("yyyyMMdd")}{Path.GetExtension(baseFilePath)}"
            );

            // Act
            provider.DisplayLogEntry(logEntry);

            // Assert: il file ruotato esiste ed il contenuto contiene il testo atteso.
            Assert.IsTrue(File.Exists(expectedFile), "Il file di log ruotato non esiste.");
            string content = File.ReadAllText(expectedFile);
            Assert.IsTrue(content.Contains("Rotated: Rotated test"), "Il contenuto del file di log ruotato non è quello atteso.");

            // Cleanup: elimina eventuali file creati per il test.
            if (File.Exists(expectedFile))
            {
                File.Delete(expectedFile);
            }
            if (File.Exists(baseFilePath))
            {
                File.Delete(baseFilePath);
            }
        }
    }
}