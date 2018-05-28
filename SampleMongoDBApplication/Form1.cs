using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace SampleMongoDBApplication
{
    public partial class Form1 : Form
    {
        private IMongoDatabase _database { get; }
        MongoClient client = new MongoClient("mongodb://localhost:27017");
       
        public Form1()
        {
            InitializeComponent();                                   
        }
            

        private void button1_Click(object sender, EventArgs e)
        {
            IMongoDatabase db = client.GetDatabase("test");
            var obj = db.GetCollection<BsonDocument>("test");
            string val = txtsearch.Text;
            var filter = Builders<BsonDocument>.Filter.Eq("status", val);
            var result = obj.Find(filter).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("status", typeof(string));
            foreach (var item in result)
            {
                dt.Rows.Add(item["item"]);
                dt.Rows.Add(item["status"]);
            }
            grid1.DataSource = dt;
        }
    }

}

//            var documents = new[]
//{
//    new BsonDocument
//    {
//        { "item", "journal" },
//        { "status", "A" },
//        { "size", new BsonDocument { { "h", 14 }, { "w", 21 }, { "uom", "cm" } } },
//        { "instock", new BsonArray
//            {
//                new BsonDocument { { "warehouse", "A" }, { "qty", 5 } } }
//            }
//    },
//    new BsonDocument
//    {
//        { "item", "notebook" },
//        { "status", "A" },
//        { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
//        { "instock", new BsonArray
//            {
//                new BsonDocument { { "warehouse", "C" }, { "qty", 5 } } }
//            }
//    },
//    new BsonDocument
//    {
//        { "item", "paper" },
//        { "status", "D" },
//        { "size", new BsonDocument { { "h", 8.5 }, { "w", 11 }, { "uom", "in" } } },
//        { "instock", new BsonArray
//            {
//                new BsonDocument { { "warehouse", "A" }, { "qty", 60 } } }
//            }
//    },
//    new BsonDocument
//    {
//        { "item", "planner" },
//        { "status", "D" },
//        { "size", new BsonDocument { { "h", 22.85 }, { "w", 30 }, { "uom", "cm" } } },
//        { "instock", new BsonArray
//            {
//                new BsonDocument { { "warehouse", "A" }, { "qty", 40 } } }
//            }
//    },
//    new BsonDocument
//    {
//        { "item", "postcard" },
//        { "status", "A" },
//        { "size", new BsonDocument { { "h", 10 }, { "w", 15.25 }, { "uom", "cm" } } },
//        { "instock", new BsonArray
//            {
//                new BsonDocument { { "warehouse", "B" }, { "qty", 15 } },
//                new BsonDocument { { "warehouse", "C" }, { "qty", 35 } } }
//            }
//    }
//};
//            obj.InsertMany(documents);

