import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_interfaces/pagination';
import { SchoolYear } from '../_interfaces/school-year';

@Injectable({
  providedIn: 'root'
})
export class SchoolYearService {
  baseurl:string= environment.baseUrl;
    
 


  paginatedResult:PaginatedResult<SchoolYear[]>= new PaginatedResult<SchoolYear[]>();
    
    constructor(private http:HttpClient) { }
    getAllSchoolYears(pageNumber?:number,pageSize?:number){
      const parmsObj={
    
        pageNumber:pageNumber||'',
        pageSize:pageSize||''
      };
      const params = new HttpParams({fromObject:parmsObj});
      return this.http.get<SchoolYear[]>(this.baseurl +'school-years',{observe:'response',params}).pipe(
        map(response=>{
          this.paginatedResult.result=response.body;
          if(response.headers.get('x-pagination')!==null){
            this.paginatedResult.pagination=JSON.parse(response.headers.get('x-pagination'));
          }
         
          return this.paginatedResult;
        })
      )
    }


  getAllPublishedSchoolYears():Observable<SchoolYear[]>{
    return this.http.get<SchoolYear[]>(this.baseurl +'school-years/published' )
  }

  getAllDraftSchoolYears():Observable<SchoolYear[]>{
    return this.http.get<SchoolYear[]>(this.baseurl +'school-years/draft' )
  }
  getSchoolYearById(SchoolYearId:number){
    return this.http.get<SchoolYear>(this.baseurl +'school-years/'+SchoolYearId )
  }

  addNewSchoolYear(SchoolYear:any){
    return this.http.post<SchoolYear>(this.baseurl+'school-years/',SchoolYear);
  }
  updateSchoolYear(SchoolYearId:number,SchoolYear:any){
    return this.http.put(this.baseurl+'school-years/'+SchoolYearId,SchoolYear);
  }

  publishSchoolYear(SchoolYearId:number){
    return this.http.put(this.baseurl+'school-years/'+SchoolYearId,null);
  }
  setToDraftSchoolYear(SchoolYearId:number){
    return this.http.put(this.baseurl+'school-years/'+SchoolYearId,null);
  }
  moveToBinSchoolYear(SchoolYearId:number){
    return this.http.put(this.baseurl+'school-years/'+SchoolYearId,null);
  }
  permDeleteSchoolYear(SchoolYearId:number){
    return this.http.delete(this.baseurl+'school-years/'+SchoolYearId);
  }
}
