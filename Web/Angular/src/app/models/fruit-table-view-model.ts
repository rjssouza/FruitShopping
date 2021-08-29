export class FruitTableViewModel {
  id: string;
  name: string;
  description: string;
  price: number;
  pictureUrl: string;
  quantity: number;

  constructor(id, name, description = '', price = 0, pictureUrl = 'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR608TWmLRWFNYPlY5xgKkgZPYe7mwv0GDMDtAS9nRdlVo4aytG', quantity = 0) {
    this.id = id
    this.name = name
    this.description = description
    this.price = price
    this.pictureUrl = pictureUrl
    this.quantity = quantity;
  }
}