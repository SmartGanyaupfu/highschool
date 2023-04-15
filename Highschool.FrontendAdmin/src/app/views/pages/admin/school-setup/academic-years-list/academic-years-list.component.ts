import { Component, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { DataTable } from 'simple-datatables';
import { Pagination } from 'src/app/_interfaces/pagination';
import { SchoolYear } from 'src/app/_interfaces/school-year';
import { SchoolYearService } from 'src/app/_services/school-year.service';

@Component({
  selector: 'app-academic-years-list',
  templateUrl: './academic-years-list.component.html',
  styleUrls: ['./academic-years-list.component.scss']
})
export class AcademicYearsListComponent implements OnInit {
  schoolYears:SchoolYear[]=[];
  public pagination:Pagination;
  pageNumber:number=1;
  pageSize:number=2;

  constructor( private schoolYearService:SchoolYearService) { }

  ngOnInit(): void {

    const dataTable = new DataTable("#academicYearsTable");
    this.getSchoolYears()
   
  }

  getSchoolYears(){
    this.schoolYearService.getAllSchoolYears(this.pageNumber,this.pageSize).subscribe(res=>{
      this.schoolYears=res.result;
      //this.pagination=res.pagination;
      console.log(res);
    })
  }

  pageChanged(event:PageChangedEvent){
    this.pageNumber=event.page;
    this.getSchoolYears();
  }
}
