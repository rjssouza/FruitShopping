import { Component, OnInit } from '@angular/core';

import { FruitService } from 'src/app/services/fruit.service'
import { Fruit } from 'src/app/models/fruit';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  fruitList: Fruit[] = []

  constructor(
    private fruitService: FruitService,
  ) { }

  ngOnInit() {
    this.loadViewModel();
  }

  loadViewModel() {
    this.fruitService.getViewModel().subscribe((fruitViewModel) => {
      this.fruitList = fruitViewModel.fruitList;
    })
  }
}
