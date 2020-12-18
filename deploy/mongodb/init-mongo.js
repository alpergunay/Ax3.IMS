var db = connect("mongodb://imsuser:ax32020!@localhost:27017/admin");
db = db.getSiblingDB('ims'); // we can not use "use" statement here to switch db
db.createUser({
    user: "imsuser",
    pwd: "ax32020!",
    roles:[
        {
            role: "readWrite",
            db: "ims"
        }
    ]
})