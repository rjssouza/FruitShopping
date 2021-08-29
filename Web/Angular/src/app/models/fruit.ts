import * as internal from "assert";

export class Fruit {
  id: string;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
  quantity: number;

  constructor(id, name, description = '', price = 0, imageUrl = 'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR608TWmLRWFNYPlY5xgKkgZPYe7mwv0GDMDtAS9nRdlVo4aytG', quantity = 0) {
    this.id = id
    this.name = name
    this.description = description
    this.price = price
    this.imageUrl = imageUrl
    this.quantity = quantity;
  }
}
