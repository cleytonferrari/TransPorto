using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;

namespace Repositorio
{
    public class Contexto<T>
    {
        private readonly MongoDatabase _database;
        private readonly MongoServer _server;

        private static string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
                   ConfigurationManager.ConnectionStrings["CSTSI"].ConnectionString;
        }
        public Contexto()
        {
            var url = new MongoUrl(GetMongoDbConnectionString());
            var client = new MongoClient(url);
            _server = client.GetServer();
            _database = _server.GetDatabase(url.DatabaseName);
            Collection = _database.GetCollection<T>(typeof(T).Name.ToLower());

            DateTimeSerializationOptions.Defaults = new DateTimeSerializationOptions(DateTimeKind.Local, BsonType.Document);

            var conventions = new ConvensoesMongo();
            ConventionRegistry.Register("Convensoes", conventions, t => true);

        }
        public MongoCollection<T> Collection { get; private set; }
        public Dictionary<string, string> BuscarArquivo(string id, ref MemoryStream retorno)
        {
            var fileInfo = _database.GridFS.FindOne(Query.EQ("_id", new BsonObjectId(new ObjectId(id))));
            var mySetting = new MongoGridFSSettings();
            var gfs = new MongoGridFS(_server, _database.Name, mySetting);

            gfs.Download(retorno, fileInfo);
            return new Dictionary<string, string> { { fileInfo.ContentType, fileInfo.Name } };
        }
        public void ExcluirArquivo(string id)
        {
            var mySetting = new MongoGridFSSettings();
            var gfs = new MongoGridFS(_server, _database.Name, mySetting);
            gfs.Delete(Query.EQ("_id", new BsonObjectId(new ObjectId(id))));
        }
        public string InserirArquivo(Stream arquivo, string nome, string contentType)
        {
            var mySetting = new MongoGridFSSettings();
            var gfs = new MongoGridFS(_server, _database.Name, mySetting);
            var fileInfo = gfs.Upload(arquivo, nome);
            gfs.SetContentType(fileInfo, contentType);
            return fileInfo.Id.AsObjectId.ToString();
        }
    }
    public class ConvensoesMongo : IConventionPack
    {
        public IEnumerable<IConvention> Conventions
        {
            get
            {
                return new List<IConvention>
                             {
                                 new IgnoreExtraElementsConvention(true)
                             };
            }
        }
    }
}