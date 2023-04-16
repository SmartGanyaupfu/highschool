import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { StudentLevel } from '../_interfaces/student-level';

@Injectable({
  providedIn: 'root'
})
export class StudentLevelService {
  baseurl:string= environment.baseUrl;
    
  constructor(private http:HttpClient) { }


  getAllStudentLevels():Observable<StudentLevel[]>{
    return this.http.get<StudentLevel[]>(this.baseurl +'student-levels' )
  }

  getAllPublishedStudentLevels():Observable<StudentLevel[]>{
    return this.http.get<StudentLevel[]>(this.baseurl +'student-levels/published' )
  }

  getAllDrafStudentLevels():Observable<StudentLevel[]>{
    return this.http.get<StudentLevel[]>(this.baseurl +'student-levels/draft' )
  }
  getStudentLevelById(studentLevelId:number){
    return this.http.get<StudentLevel>(this.baseurl +'student-levels/'+studentLevelId )
  }

  addNewStudentLevel(StudentLevel:any){
    return this.http.post<StudentLevel>(this.baseurl+'student-levels/',StudentLevel);
  }
  updateStudentLevel(studentLevelId:number,StudentLevel:any){
    return this.http.put(this.baseurl+'student-levels/'+studentLevelId,StudentLevel);
  }

  publishStudentLevel(studentLevelId:number){
    return this.http.put(this.baseurl+'student-levels/'+studentLevelId,null);
  }
  setToDraftStudentLevel(studentLevelId:number){
    return this.http.put(this.baseurl+'student-levels/'+studentLevelId,null);
  }
  moveToBinStudentLevel(studentLevelId:number){
    return this.http.put(this.baseurl+'student-levels/'+studentLevelId,null);
  }
  permDeleteStudentLevel(studentLevelId:number){
    return this.http.delete(this.baseurl+'student-levels/'+studentLevelId);
  }
}
