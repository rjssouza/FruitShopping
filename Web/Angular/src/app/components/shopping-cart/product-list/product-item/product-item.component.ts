import { Component, OnInit, Input } from '@angular/core';
import { FruitTableViewModel } from 'src/app/models/fruit-table-view-model'
import { MessengerService } from 'src/app/services/messenger.service'
import { CartService } from 'src/app/services/cart.service'
import { JwksValidationHandler, OAuthService } from 'angular-oauth2-oidc';
import { FruitService } from 'src/app/services/fruit.service'

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() productItem: FruitTableViewModel;

  constructor(
    private msg: MessengerService,
    private cartService: CartService,    
    private fruitService: FruitService,
    private oauthService: OAuthService
  ) { }

  ngOnInit() {
    this.handleSubscription();
  }

  handleSubscription() {
    this.msg.getMsg().subscribe((product: FruitTableViewModel) => {
      if(product.id != this.productItem.id)
        return;

      this.fruitService.getById(product.id).subscribe((fruitTableViewModel) => {
        debugger;
        this.productItem = fruitTableViewModel;
      });
    })
  }

  handleAddToCart() {
    this.validateLogin();
    this.cartService.addProductToCart(this.productItem).subscribe(() => {
      this.msg.sendMsg(this.productItem);
    })
  }

  validateLogin() {
    if(! this.oauthService.hasValidAccessToken()){
      this.oauthService.initLoginFlow();
    }
  }
}
