//using MongoDB.Driver;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace mot_api.Data
//{
//    public sealed class SingletonMongoConnection
//    {
//        private static SingletonMongoConnection _instance = null;
//        private static readonly object _lock = new Object();
//        private int _nCounter = 0;

//        MongoClient _client;
//        MongoServerAddress _server;
//        MongoDatabaseBase _db;

//        public static SingletonMongoConnection Instance
//        {
//            get
//            {
//                lock (_lock)
//                {
//                    if(_instance == null)
//                    {
//                        _instance = new SingletonMongoConnection();
//                    }
//                    return _instance;
//                }
//            }
//        }

//        private SingletonMongoConnection()
//        {
//            _nCounter = 1;
//        }
        
//        public void MongoAccess()
//        {
//            _client = new MongoClient("mongodb://localhost:27017");
//            //_server = _client.GetDatabase("mot", [settings = null]);
//            _db = _client.GetDatabase("mot");
//        }
//    }
//}
