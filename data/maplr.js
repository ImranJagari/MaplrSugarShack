/*
 Navicat Premium Data Transfer

 Source Server         : Local Mongo
 Source Server Type    : MongoDB
 Source Server Version : 60002
 Source Host           : localhost:27017
 Source Schema         : maplr

 Target Server Type    : MongoDB
 Target Server Version : 60002
 File Encoding         : 65001

 Date: 07/04/2023 15:49:42
*/


db = db.getSiblingDB('maplr')
// ----------------------------
// Collection structure for cart
// ----------------------------
db.getCollection("cart").drop();
db.createCollection("cart");

// ----------------------------
// Documents of cart
// ----------------------------

// ----------------------------
// Collection structure for products
// ----------------------------
db.getCollection("products").drop();
db.createCollection("products");

// ----------------------------
// Documents of products
// ----------------------------
db.getCollection("products").insert([ {
    _id: ObjectId("64305773b25067d558211699"),
    LastModifiedTime: ISODate("0001-01-01T00:00:00.000Z"),
    Name: "Test MapleSyrup Clear",
    Quantity: NumberInt("10"),
    Description: "Test description for MapleSyrup Clear",
    ImageUrl: "images/syrups/0.jpg",
    Price: 100,
    Type: NumberInt("0")
} ]);
db.getCollection("products").insert([ {
    _id: ObjectId("64305adeb25067d55821169a"),
    Name: "Test MapleSyrup Amber",
    Quantity: NumberInt("10"),
    Description: "Test description for MapleSyrup Amber",
    ImageUrl: "images/syrups/1.jpg",
    Price: 75.15,
    Type: NumberInt("1")
} ]);
db.getCollection("products").insert([ {
    _id: ObjectId("64305c05b25067d55821169b"),
    LastModifiedTime: ISODate("0001-01-01T00:00:00.000Z"),
    Name: "Test MapleSyrup Dark",
    Quantity: NumberInt("1"),
    Description: "Test description for MapleSyrup Dark",
    ImageUrl: "images/syrups/2.jpg",
    Price: 50,
    Type: NumberInt("2")
} ]);
