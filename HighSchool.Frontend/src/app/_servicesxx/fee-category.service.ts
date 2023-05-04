import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FeeCategory } from '../_interfaces/fee-category';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeeCategoryService {
  baseurl:string= environment.baseUrl;
    
  constructor(private http:HttpClient) { }


  getAllFeeCategories(){
    return this.http.get<FeeCategory[]>(this.baseurl +'fee-categories' )
  }

  getAllPublishedFeeCategories():Observable<FeeCategory[]>{
    return this.http.get<FeeCategory[]>(this.baseurl +'fee-categories/published' )
  }

  getAllDraftFeeCategories():Observable<FeeCategory[]>{
    return this.http.get<FeeCategory[]>(this.baseurl +'fee-categories/draft' )
  }
  getFeeCategoryById(feeCategoryId:number){
    return this.http.get<FeeCategory>(this.baseurl +'fee-categories/'+feeCategoryId )
  }

  addNewFeeCategory(feeCategory:any){
    return this.http.post<FeeCategory>(this.baseurl+'feee-categories/',feeCategory);
  }
  updateFeeCategory(feeCategoryId:number,feeCategory:any){
    return this.http.put(this.baseurl+'fee-categories/'+feeCategoryId,feeCategory);
  }

  publishFeeCategory(feeCategoryId:number){
    return this.http.put(this.baseurl+'fee-categories/'+feeCategoryId,null);
  }
  setToDraftFeeCategory(feeCategoryId:number){
    return this.http.put(this.baseurl+'fee-categories/'+feeCategoryId,null);
  }
  moveToBinFeeCategory(feeCategoryId:number){
    return this.http.put(this.baseurl+'fee-categories/'+feeCategoryId,null);
  }
  permDeleteFeeCategory(feeCategoryId:number){
    return this.http.delete(this.baseurl+'fee-categories/'+feeCategoryId);
  }
}
