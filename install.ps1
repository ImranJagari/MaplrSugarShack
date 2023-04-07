docker build -t "maplr:Dockerfile" .
docker run -itd -p 27017:27017 --name maplrMongo "maplr:Dockerfile"
docker exec -it maplrMongo mongosh "mongodb://127.0.0.1:27017" --eval "load('/data/db/maplr.js')"
