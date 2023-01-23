using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WordGame.Core;

namespace WordGame.DataBase
{
    public class MongoDataBase
    {
        public static void AddToDataBase(Question question)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("WordGame");
            var collection = database.GetCollection<Question>("QuestionList");
            collection.InsertOne(question);
        }

        public static Question[] FindQuestion()
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            IMongoDatabase database = client.GetDatabase("WordGame");
            var collection = database.GetCollection<Question>("QuestionList");
            var question = collection.Find(x => true).ToList().ToArray();
            var random = new Random();

            for (int i = question.Length - 1; i >= 1; i--)
            {
                int rnd = random.Next(i + 1);
                var temp = question[rnd];
                question[rnd] = question[i];
                question[i] = temp;
            }

            return question;
        }
    }
}
