﻿using PriorityStreamsExtractor.Initializer;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityStreamsExtractor.StreamsHandler
{
    public class TotalWorker
    {
        /// <summary>
        /// holds the last id we Acked for each stream
        /// </summary>
        public static Dictionary<string, RedisValue> lastId = new Dictionary<string, RedisValue>();

        /// <summary>
        /// Sets the database from which we will extract messages.
        /// this database the redis database that Priority Stream Service Writes To.
        /// Here are the Messages all sorted and set and we only read (extract them) 
        /// then write them to whatever interface we want.
        /// </summary>
        /// <param name="RedisRead"></param>
        /// <exception cref="throws exeception if could not connect to redis database"> </exception>

        private static readonly string RedisRead = ReadRedisInfoParser.connection;

        private static readonly string RedisWrite = WriteRedisInfoParser.connection;
        
        public static void setAll()
        {
            if (!Extractor.Extractor.setDatabase(RedisRead))
            {
                //Console.WriteLine("ERROR : " + RedisRead);
                throw new Exception("ERROR : " + RedisRead);
            }

            if (!Writer.Writer.setDatabase(RedisWrite))
            {
                //Console.WriteLine("ERROR: " + RedisWrite);
                throw new Exception("ERROR: " + RedisWrite);

            }
        }

        /// <summary>
        /// Extract Messages from stream while ensuring ALL MESSAGES ARE READ
        /// Keeps Track of last Acked ID in each stream
        /// </summary>
        /// <param name="stream"></param>
        public static void work(string stream)
        {
            RedisValue id = (lastId.ContainsKey(stream) ? lastId[stream] : "0-0");

            RedisValue new_id = Extractor.Extractor.ProcessMessagesAsync(stream, id).Result;

            lastId[stream] = new_id;
        }
    }
}
