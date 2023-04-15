import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SchoolTerm } from '../_interfaces/school-term';

@Injectable({
  providedIn: 'root'
})
export class SchoolTermService {

  baseurl:string= environment.baseUrl;
    
    constructor(private http:HttpClient) { }


    getAllSchoolTerms():Observable<SchoolTerm[]>{
      return this.http.get<SchoolTerm[]>(this.baseurl +'school-terms' )
    }
  
    getAllPublishedSchoolTerms():Observable<SchoolTerm[]>{
      return this.http.get<SchoolTerm[]>(this.baseurl +'school-terms/published' )
    }

    getAllDrafSchoolTerms():Observable<SchoolTerm[]>{
      return this.http.get<SchoolTerm[]>(this.baseurl +'school-terms/draft' )
    }
    getSchoolTermById(SchoolTermId:number){
      return this.http.get<SchoolTerm>(this.baseurl +'school-terms/'+SchoolTermId )
    }
  
    addNewSchoolTerm(SchoolTerm:any){
      return this.http.post<SchoolTerm>(this.baseurl+'school-terms/',SchoolTerm);
    }
    updateSchoolTerm(SchoolTermId:number,SchoolTerm:any){
      return this.http.put(this.baseurl+'school-terms/'+SchoolTermId,SchoolTerm);
    }

    publishSchoolTerm(schoolTermId:number){
      return this.http.put(this.baseurl+'school-terms/'+schoolTermId,null);
    }
    setToDraftSchoolTerm(schoolTermId:number){
      return this.http.put(this.baseurl+'school-terms/'+schoolTermId,null);
    }
    moveToBinSchoolTerm(schoolTermId:number){
      return this.http.put(this.baseurl+'school-terms/'+schoolTermId,null);
    }
    permDeleteSchoolTerm(schoolTermId:number){
      return this.http.delete(this.baseurl+'school-terms/'+schoolTermId);
    }
}
