import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { StudentClass } from '../_interfaces/student-class';

@Injectable({
  providedIn: 'root'
})
export class StudentClasseService {
  baseurl:string= environment.baseUrl;
    
  constructor(private http:HttpClient) { }


  getAllStudentClasses():Observable<StudentClass[]>{
    return this.http.get<StudentClass[]>(this.baseurl +'student-classes' )
  }

  getAllPublishedStudentClasses():Observable<StudentClass[]>{
    return this.http.get<StudentClass[]>(this.baseurl +'student-classes/published' )
  }

  getAllDrafStudentClasses():Observable<StudentClass[]>{
    return this.http.get<StudentClass[]>(this.baseurl +'student-classes/draft' )
  }
  getStudentClassById(studentClassId:number){
    return this.http.get<StudentClass>(this.baseurl +'student-classes/'+studentClassId )
  }

  addNewStudentClass(StudentClass:any){
    return this.http.post<StudentClass>(this.baseurl+'student-classes/',StudentClass);
  }
  updateStudentClass(studentClassId:number,StudentClass:any){
    return this.http.put(this.baseurl+'student-classes/'+studentClassId,StudentClass);
  }

  publishStudentClass(studentClassId:number){
    return this.http.put(this.baseurl+'student-classes/'+studentClassId,null);
  }
  setToDraftStudentClass(studentClassId:number){
    return this.http.put(this.baseurl+'student-classes/'+studentClassId,null);
  }
  moveToBinStudentClass(studentClassId:number){
    return this.http.put(this.baseurl+'student-classes/'+studentClassId,null);
  }
  permDeleteStudentClass(studentClassId:number){
    return this.http.delete(this.baseurl+'student-classes/'+studentClassId);
  }
}
