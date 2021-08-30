import { Component, OnInit } from '@angular/core';
import { MessengerService } from 'src/app/services/messenger.service'
import { FruitTableViewModel } from 'src/app/models/fruit-table-view-model';
import { CartService } from 'src/app/services/cart.service';
import { Cart } from 'src/app/models/cart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartItems = [];

  cartTotal = 0

  constructor(
    private msg: MessengerService,
    private cartService: CartService
  ) { }

  ngOnInit() {
    this.handleSubscription();
    this.loadViewModel();
  }

  handleSubscription() {
    this.msg.getMsg().subscribe((product: FruitTableViewModel) => {
      this.loadViewModel();
    })
  }

  loadViewModel() {
    this.cartService.getViewModel().subscribe((cartViewModel: Cart) => {
      if (!cartViewModel)
        return;
      
      this.cartItems = cartViewModel.items;
      this.calcCartTotal();
    })
  }

  calcCartTotal() {
    this.cartTotal = 0
    this.cartItems.forEach(item => {
      this.cartTotal += (item.quantity * item.price)
    })
  }
}
