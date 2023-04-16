import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { StudentSession } from '../_interfaces/student-session';

@Injectable({
  providedIn: 'root'
})
export class StudentSessionService {
  baseurl:string= environment.baseUrl;
    
  constructor(private http:HttpClient) { }


  getAllStudentSessions():Observable<StudentSession[]>{
    return this.http.get<StudentSession[]>(this.baseurl +'student-classes' )
  }

  getAllPublishedStudentSessions():Observable<StudentSession[]>{
    return this.http.get<StudentSession[]>(this.baseurl +'student-classes/published' )
  }

  getAllDrafStudentSessions():Observable<StudentSession[]>{
    return this.http.get<StudentSession[]>(this.baseurl +'student-classes/draft' )
  }
  getStudentSessionById(studentSessionId:number){
    return this.http.get<StudentSession>(this.baseurl +'student-classes/'+studentSessionId )
  }

  addNewStudentSession(StudentSession:any){
    return this.http.post<StudentSession>(this.baseurl+'student-classes/',StudentSession);
  }
  updateStudentSession(studentSessionId:number,StudentSession:any){
    return this.http.put(this.baseurl+'student-classes/'+studentSessionId,StudentSession);
  }

  publishStudentSession(studentSessionId:number){
    return this.http.put(this.baseurl+'student-classes/'+studentSessionId,null);
  }
  setToDraftStudentSession(studentSessionId:number){
    return this.http.put(this.baseurl+'student-classes/'+studentSessionId,null);
  }
  moveToBinStudentSession(studentSessionId:number){
    return this.http.put(this.baseurl+'student-classes/'+studentSessionId,null);
  }
  permDeleteStudentSession(studentSessionId:number){
    return this.http.delete(this.baseurl+'student-classes/'+studentSessionId);
  }
}
