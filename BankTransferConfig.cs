using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022330117
{
     class BankTransferConfig
    {
        private string filePath = "bank_transfer_config.json";
        public string lang {  set; get; }
        public class Transfer
        {
            public int tthreshold { set; get; }
            public int low_fee { set; get; }
            public int high_fee { set; get; }
        }
        public Transfer transfer { set; get; }
        public List<string> methods { set; get; }
        public class Confirmation
        {
            public string en { set; get; }
            public string id { set; get; }
        }
        public Confirmation confirmation { set; get; }
      }

    class UIConfig
    {
        public BankTransferConfig bankTransferConfig;
        public const string filePath = @"bank_transfer_config.json";
        public UIConfig()
        {
            try
            {
                readConfigFile();
            }
            catch {
                setDefault();
                WriteNewConfigFile();
            }
        }
        private BankTransferConfig readConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            bankTransferConfig = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
            return bankTransferConfig;
        }

        private void setDefault()
        {

        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(bankTransferConfig, options);
            File.WriteAllText(filePath, jsonString);
        }


       
    }




}

//public BankTransferConfig()
//{
//    if (File.Exists(filePath))
//    {
//        string json = File.ReadAllText(filePath);

//        BankTransferConfigData? config = JsonSerializer.Deserialize<BankTransferConfigData>(json);

//        if (config != null)
//        {
//            lang = config.lang;
//            transfer = config.transfer;
//            methods = config.methods;
//            confirmation = config.confirmation;
//        }
//    }
//    else
//    {
//        lang = "en";
//        transfer = 
//}
