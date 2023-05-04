import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FeeCategory } from 'src/app/_interfaces/fee-category';
import { Pagination } from 'src/app/_interfaces/pagination';
import { FeeCategoryService } from 'src/app/_services/fee-category.service';

@Component({
  selector: 'app-fee-category-list',
  templateUrl: './fee-category-list.component.html',
  styleUrls: ['./fee-category-list.component.scss']
})
export class FeeCategoryListComponent {

 
  //dataSource :any;
 

 

  opened: boolean;
  public pagination:Pagination;
  pageNumber:number=1;
  pageSize:number=12;
  categories:FeeCategory[];
  displayedColumns: string[] = [ 'name'];
  dataSource :FeeCategory[]=[];
 


pageIndex:number;

length:number;
  constructor(  private feeCategoryService: FeeCategoryService) { }

  ngOnInit(): void {
   this.getCategories();
   
    
  }
 
getCategories(){
  this.feeCategoryService.getAllFeeCategories().subscribe(res=>{
    this.categories=res;
    this.dataSource=this.categories;
    //this.dataSource = new MatTableDataSource<FeeCategory>(res);
  })
}

pageChanged(event){
 // this.pageNumber=event.page;
 console.log(event);

}

}









