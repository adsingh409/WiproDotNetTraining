using System;
using System.Collections.Generic;

namespace SolidAndDesignPatterns
{
    // ===================== SRP =====================
    public class ReportGenerator
    {
        public string GenerateReport()
        {
            return "Report Data Generated";
        }
    }

    public class ReportSaver
    {
        public void SaveToFile(string data)
        {
            Console.WriteLine("Saving Report: " + data);
        }
    }

    // ===================== OCP =====================
    public interface IReportFormatter
    {
        string Format(string data);
    }

    public class PdfFormatter : IReportFormatter
    {
        public string Format(string data)
        {
            return "PDF: " + data;
        }
    }

    public class ExcelFormatter : IReportFormatter
    {
        public string Format(string data)
        {
            return "Excel: " + data;
        }
    }

    public class ReportFormatter
    {
        private IReportFormatter _formatter;

        public ReportFormatter(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public string FormatReport(string data)
        {
            return _formatter.Format(data);
        }
    }

    // ===================== LSP =====================
    public abstract class Report
    {
        public abstract string GetContent();
    }

    public class SalesReport : Report
    {
        public override string GetContent()
        {
            return "Sales Report Content";
        }
    }

    public class FinanceReport : Report
    {
        public override string GetContent()
        {
            return "Finance Report Content";
        }
    }

    // ===================== ISP =====================
    public interface IGenerateReport
    {
        string Generate();
    }

    public interface ISaveReport
    {
        void Save(string data);
    }

    public class SimpleReport : IGenerateReport
    {
        public string Generate()
        {
            return "Simple Report Generated";
        }
    }

    public class FileSaver : ISaveReport
    {
        public void Save(string data)
        {
            Console.WriteLine("Saved: " + data);
        }
    }

    // ===================== DIP =====================
    public class ReportService
    {
        private readonly IGenerateReport _generator;
        private readonly ISaveReport _saver;

        public ReportService(IGenerateReport generator, ISaveReport saver)
        {
            _generator = generator;
            _saver = saver;
        }

        public void ProcessReport()
        {
            var data = _generator.Generate();
            _saver.Save(data);
        }
    }

    // ===================== Singleton =====================
    public class Logger
    {
        private static Logger _instance;

        private Logger() { }

        public static Logger GetInstance()
        {
            if (_instance == null)
                _instance = new Logger();

            return _instance;
        }

        public void Log(string message)
        {
            Console.WriteLine("Log: " + message);
        }
    }

    // ===================== Factory =====================
    public interface IDocument
    {
        void Open();
    }

    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening PDF Document");
        }
    }

    public class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Word Document");
        }
    }

    public class DocumentFactory
    {
        public static IDocument CreateDocument(string type)
        {
            if (type == "PDF")
                return new PdfDocument();
            else if (type == "WORD")
                return new WordDocument();
            else
                throw new Exception("Invalid type");
        }
    }

    // ===================== Observer =====================
    public interface IObserver
    {
        void Update(string data);
    }

    public interface ISubject
    {
        void Register(IObserver observer);
        void Remove(IObserver observer);
        void Notify();
    }

    public class WeatherStation : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string weatherData;

        public void SetWeather(string data)
        {
            weatherData = data;
            Notify();
        }

        public void Register(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(weatherData);
            }
        }
    }

    public class WeatherDisplay : IObserver
    {
        public void Update(string data)
        {
            Console.WriteLine("Weather Update: " + data);
        }
    }

    // ===================== MAIN =====================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SOLID Principles ===");

            // SRP
            var generator = new ReportGenerator();
            var saver = new ReportSaver();
            var data = generator.GenerateReport();
            saver.SaveToFile(data);

            // OCP
            var formatter = new ReportFormatter(new PdfFormatter());
            Console.WriteLine(formatter.FormatReport("Test Data"));

            // LSP
            Report report = new SalesReport();
            Console.WriteLine(report.GetContent());

            // ISP + DIP
            var simpleReport = new SimpleReport();
            var fileSaver = new FileSaver();
            var service = new ReportService(simpleReport, fileSaver);
            service.ProcessReport();

            Console.WriteLine("\n=== Design Patterns ===");

            // Singleton
            var logger1 = Logger.GetInstance();
            var logger2 = Logger.GetInstance();
            logger1.Log("Singleton Working");
            Console.WriteLine("Same Instance: " + object.ReferenceEquals(logger1, logger2));

            // Factory
            var doc = DocumentFactory.CreateDocument("PDF");
            doc.Open();

            // Observer
            var station = new WeatherStation();
            var display = new WeatherDisplay();
            station.Register(display);
            station.SetWeather("Rainy");
        }
    }
}
