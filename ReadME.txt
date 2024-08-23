how to run project

Docker:

docker pull redis:latest

docker pull mongo:latest

docker pull jaegertracing/all-in-one:1.59

docker pull steeltoeoss/eureka-server

/////////////////////////////////////////////////////

run instance of eureka on port 8761 // name it service-discovery

run instance of redis on port 6379 // name it insert-sort-redis

run instance of redis on port 6400 //name it final-consumer-redis

run instance of Mongo on port 27017 //name it scheduled messages

run instance of Mongo on port 27020 // name it Accounts

run instance of Jaeger as follows:

docker run -d --name jaeger -e COLLECTOR_ZIPKIN_HOST_PORT=:9411   -p 5775:5775/udp   -p 6831:6831/udp   -p 6832:6832/udp   -p 5778:5778   -p 16686:16686   -p 14268:14268   -p 14250:14250   -p 9411:9411   jaegertracing/all-in-one:1.59


////////////////////////////////////////////////////
Then Run Project as follows:
1- Validator
2- Schdeuler
3- ScheduledMessagesHandler
4- PriorityStreamExtractor
5- HTTPMessagesNode
6- GRPCMessagesNode
7- FinalMessageConsumer

and check everyone for exceptoins thrown (Happens only when a funamental service not working like database or redis)
////////////////////////////////////////////////////

monitor with jaegar : http://localhost:16686/search
Services in Eureka : http://localhost:8761/

/////////////////////////////////////////////////////

Then in the Projects HttpEndUSer and Http2EndUser:
go to bin\Debug\net6.0-windows and run the exe

Enjoy!!
////////////////////////////////////////////////





