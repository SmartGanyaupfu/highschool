//import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, TemplateRef, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'HighSchool.Frontend';
  //@ViewChild(MatSidenav) sidenav!:MatSidenav;
  events: string[] = [];
  opened: boolean=true;
  panelOpenState = false;

 
  constructor(){}
  
  /*constructor(public observer: BreakpointObserver){}
  ngAfterViewInit() {
    setTimeout(()=>{
      this.getViewPort();
    },0)
   }
  
   getViewPort(){
     this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
       if (res.matches) {
         this.sidenav.mode = 'over';
         
         this.sidenav.close();
       } else {
         this.sidenav.mode = 'side';
         this.sidenav.open();
       }
     });
   }
*/
}
