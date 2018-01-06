# Simple performance analysis on [Elasticsearch.Net & NEST](https://github.com/elastic/elasticsearch-net) package. 

Docker can be used to work on the application with these commands:
```sh
$ docker pull docker.elastic.co/elasticsearch/elasticsearch:5.6.5
$ docker run --name elastic -d -p 9200:9200 -p 9300:9300 -e "http.host=0.0.0.0" -e "transport.host=127.0.0.1" -e "xpack.security.enabled=false" docker.elastic.co/elasticsearch/elasticsearch:5.6.5
```

## Test Results (50 requests)

| /Home/Singleton | /Home/PerRequest |
| ------ | ------ |
| *ConnectionSettings* instance is instantiated as singleton | *ConnectionSettings* instance is instantiated by per request |
 | 568 ms | 328 ms | 
 | 37 ms | 427 ms | 
 | 64 ms | 371 ms | 
 | 36 ms | 306 ms | 
 | 34 ms | 312 ms | 
 | 44 ms | 276 ms | 
 | 36 ms | 255 ms | 
 | 29 ms | 230 ms | 
 | 30 ms | 227 ms | 
 | 26 ms | 283 ms | 
 | 58 ms | 298 ms | 
 | 30 ms | 292 ms | 
 | 23 ms | 230 ms | 
 | 47 ms | 258 ms | 
 | 37 ms | 248 ms | 
 | 30 ms | 232 ms | 
 | 30 ms | 247 ms | 
 | 30 ms | 232 ms | 
 | 53 ms | 331 ms | 
 | 163 ms | 390 ms | 
 | 43 ms | 262 ms | 
 | 30 ms | 275 ms | 
 | 34 ms | 263 ms | 
 | 35 ms | 244 ms | 
 | 33 ms | 256 ms | 
 | 30 ms | 243 ms | 
 | 32 ms | 281 ms | 
 | 26 ms | 341 ms | 
 | 68 ms | 337 ms | 
 | 27 ms | 240 ms | 
 | 57 ms | 283 ms | 
 | 33 ms | 243 ms | 
 | 31 ms | 302 ms | 
 | 38 ms | 260 ms | 
 | 27 ms | 280 ms | 
 | 36 ms | 325 ms | 
 | 33 ms | 243 ms | 
 | 31 ms | 248 ms | 
 | 27 ms | 279 ms | 
 | 38 ms | 257 ms | 
 | 33 ms | 262 ms | 
 | 26 ms | 225 ms | 
 | 30 ms | 234 ms | 
 | 26 ms | 246 ms | 
 | 27 ms | 242 ms | 
 | 41 ms | 300 ms | 
 | 38 ms | 303 ms | 
 | 24 ms | 276 ms | 
 | 40 ms | 340 ms | 
 | 54 ms | 306 ms | 

