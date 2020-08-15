db.createUser({
    user: "imsuser",
    pwd: ax32020!,
    roles:[
        {
            role: "readWrite",
            db: "ims"
        }
    ]
})