import { Component } from '@angular/core';
import { Pagination } from '../_interfaces/pagination';
import { FeeCategory } from '../_interfaces/fee-category';
import { FeeCategoryService } from '../_services/fee-category.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent {
  
  opened: boolean;
  public pagination:Pagination;
  pageNumber:number=1;
  pageSize:number=12;
  categories:FeeCategory[];
 
  constructor(  private feeCategoryService: FeeCategoryService) { }

  ngOnInit(): void {
   this.getCategories();
    
  }
getCategories(){
  this.feeCategoryService.getAllFeeCategories().subscribe(res=>{
    this.categories=res;
    console.log(this.categories);
  })
}

pageChanged(event){
  this.pageNumber=event.page;

}

  
}
