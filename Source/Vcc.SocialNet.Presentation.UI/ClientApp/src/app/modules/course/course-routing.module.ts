import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CoursesComponent } from './courses/courses.component';
import { CourseDetailComponent } from './course-detail/course-detail.component';
import { CourseSearchComponent } from './course-search/course-search.component';

const courseRoutes: Routes = [
  {
    path: '',
    component: CoursesComponent
  },
  {
    path: ':id',    
    component: CourseDetailComponent
  },
  {
    path: 'search',    
    component: CourseSearchComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(courseRoutes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }
