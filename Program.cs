using System;
using System.Collections.Generic;
using System.Xml;

namespace XML_Demo
{
    class Product
    {
        public string id;
        public string mah;
        public string mahaddress;
        public string mahzip;
        public string mahcountry;
        public string productname;
        public int strength;
        public string strengthunit;
        public bool rx;
        public bool renewal_upcoming;
        public string renewal_date;
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();

            // Load XML
            doc.Load(@"C:\...\Product.xml");

            // Save selected nodes in XmlNodeList-variable "nodes"
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/catalog/product");

            // Declare list in which new objects get pushed to later on
            List<Product> products_list = new List<Product>();

            // Iterate through NodeList nodes and push objects to list
            foreach (XmlNode node in nodes)
            {
                Product product_object = new Product();

                product_object.id = node.Attributes["id"].Value;
                product_object.mah = node.SelectSingleNode("mah").InnerText;
                product_object.mahaddress = node.SelectSingleNode("mah-address").InnerText;
                product_object.mahzip = node.SelectSingleNode("mah-zip").InnerText;
                product_object.mahcountry = node.SelectSingleNode("mah-country").InnerText;
                product_object.productname = node.SelectSingleNode("product_name").InnerText;
                product_object.strength = Convert.ToInt32(node.SelectSingleNode("strength").InnerText); // Converted to integer
                product_object.strengthunit = node.SelectSingleNode("strength_unit").InnerText;
                string rxbooleanevaluation = node.SelectSingleNode("rx").InnerText; // Read as string, then assigned a boolean according to condition
                if (rxbooleanevaluation == "y")
                {
                    product_object.rx = true;
                } else
                {
                    product_object.rx = false;
                }
                string renewalbooleanevaluation = node.SelectSingleNode("renewal-upcoming").InnerText; // Read as string, then assigned boolean according to condition
                if (renewalbooleanevaluation == "y")
                {
                    product_object.renewal_upcoming = true;
                }
                else
                {
                    product_object.renewal_upcoming = false;
                }
                product_object.renewal_date = node.SelectSingleNode("renewal-date").InnerText;

                // Add new object to list
                products_list.Add(product_object);

            }

            // Text-Output
            Console.WriteLine("> XML Pharma Parser <");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");

            foreach (var iterproduct in products_list)
            {
                Console.WriteLine("Product-ID: " + iterproduct.id);
                Console.WriteLine("Marketing Authorisation Holder: " + iterproduct.mah);
                Console.WriteLine("Address: " + iterproduct.mahaddress);
                Console.WriteLine("ZIP: " + iterproduct.mahzip);
                Console.WriteLine("Country: " + iterproduct.mahcountry);
                Console.WriteLine("Product Name: " + iterproduct.productname);
                Console.WriteLine("Strength: " + iterproduct.strength);
                Console.WriteLine("Strength Unit: " + iterproduct.strengthunit);
                Console.WriteLine("RX: " + iterproduct.rx);
                Console.WriteLine("Renewal Upcoming: " + iterproduct.renewal_upcoming);
                Console.WriteLine("Renewal Date: " + iterproduct.renewal_date);
                Console.WriteLine("-------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("File successfully parsed.");
            Console.WriteLine("");
            Console.WriteLine("Total products: " + products_list.Count);
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
