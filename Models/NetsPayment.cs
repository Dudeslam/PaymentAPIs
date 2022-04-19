using System;
using System.Collections.Generic;

namespace NetsEasyPOC.Models
{

    public class Item
    {
        public string reference { get; set; } = "SUDO2918";
        public string name { get; set; } = "Dark Gray Horse";
        public int quantity { get; set; } = 1;
        public string unit { get; set; } = "Vehicle";
        public double unitPrice { get; set; } = 0;
        public int taxRate { get; set; } = 0;
        public int taxAmount { get; set; } = 0;
        public double grossTotalAmount { get; set; } = 0;
        public double netTotalAmount { get; set; } = 0;
    }

    public class Order
    {
        public List<Item> items { get; set; } = new List<Item>();
        public int amount { get; set; } = 1;
        public string currency { get; set; } = "DKK";
        public string reference { get; set; } = "";
    }

    public class ShippingAddress
    {
        public string addressLine1 { get; set; } = "ThisStreet22";
        public string postalCode { get; set; } = "8000";
        public string city { get; set; } = "Aarhus";
        public string country { get; set; } = "DNK";
    }

    public class Contact
    {
        public string firstName { get; set; } = "Gurt";
        public string lastName { get; set; } = "Burt";
    }

    public class Company
    {
        public string name { get; set; } = "Bytelib";
        public Contact contact { get; set; } = new Contact();
    }

    public class Consumer
    {
        public string reference { get; set; } = "";
        public string email { get; set; } = "vtt@bytelab.dk";
        public ShippingAddress shippingAddress { get; set; } = new ShippingAddress();
        public Company company { get; set; } = new Company();
    }

    public class ConsumerType
    {
        public string @default { get; set; } = "";
        public List<string> supportedTypes { get; set; } = new List<string>();
    }

    public class DisplayOptions
    {
        public bool showMerchantName { get; set; } = true;
        public bool showOrderSummary { get; set; } = true;
    }

    public class TextOptions
    {
        public string completePaymentButtonText { get; set; } = "";
    }

    public class Appearance
    {
        public DisplayOptions displayOptions { get; set; } = new DisplayOptions();
        public TextOptions textOptions { get; set; } = new TextOptions();
    }

    public class Checkout
    {
        public string url { get; set; } = "https://localhost:44337/Home/TestPayment";
        public string integrationType { get; set; } = "EmbeddedCheckout";
        public string returnUrl { get; set; } = "https://localhost:44337/Home/TestPayment";
        public Consumer consumer { get; set; } = new Consumer();
        public string termsUrl { get; set; } = "https://localhost:44337/Home/TestPayment";
        public string merchantTermsUrl { get; set; } = "https://localhost:44337/Home/TestPayment";
        public ConsumerType consumerType { get; set; } = new ConsumerType();
        public bool charge { get; set; } = true;
        public bool publicDevice { get; set; } = true;
        public bool merchantHandlesConsumerData { get; set; } = true;
        public Appearance appearance { get; set; } = new Appearance();
        public string countryCode { get; set; } = "DNK";
    }

    public class Root
    {
        public Order order { get; set; }
        public Checkout checkout { get; set; } = new Checkout();
        public string merchantNumber { get; set; }
    }
}