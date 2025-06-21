using System;

namespace FactoryMethodPatternExample
{
    // Step 1: Define an abstract class for Document
    public abstract class Document
    {
        public abstract void Print();  // Each document should have a method to print it
    }

    // Step 2: Concrete document classes implementing the Document abstract class
    public class WordDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Printing Word Document.");
        }
    }

    public class PdfDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Printing PDF Document.");
        }
    }

    public class ExcelDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Printing Excel Document.");
        }
    }

    // Step 3: Define the abstract DocumentFactory class
    public abstract class DocumentFactory
    {
        public abstract Document CreateDocument();  // Factory method to create a document
    }

    // Step 4: Concrete factory classes for each document type
    public class WordDocumentFactory : DocumentFactory
    {
        public override Document CreateDocument()
        {
            return new WordDocument();  // Create and return a Word document
        }
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override Document CreateDocument()
        {
            return new PdfDocument();  // Create and return a PDF document
        }
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override Document CreateDocument()
        {
            return new ExcelDocument();  // Create and return an Excel document
        }
    }

    // Step 5: Main program to test the Factory Method pattern
    class Program
    {
        static void Main(string[] args)
        {
            // Step 6: Use the factory method to create different types of documents

            // Create Word document using the factory
            DocumentFactory wordFactory = new WordDocumentFactory();
            Document wordDoc = wordFactory.CreateDocument();
            wordDoc.Print();  // Prints: Printing Word Document.

            // Create PDF document using the factory
            DocumentFactory pdfFactory = new PdfDocumentFactory();
            Document pdfDoc = pdfFactory.CreateDocument();
            pdfDoc.Print();  // Prints: Printing PDF Document.

            // Create Excel document using the factory
            DocumentFactory excelFactory = new ExcelDocumentFactory();
            Document excelDoc = excelFactory.CreateDocument();
            excelDoc.Print();  // Prints: Printing Excel Document.
        }
    }
}