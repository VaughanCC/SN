import { Routes } from '@angular/router';

export const CONTENT_ROUTES: Routes = [
  // all sub-modules are configured for lazy-load as below
  {
    path: 'dashboard',
    loadChildren: './modules/home/home.module#HomeModule'
  },
  {
    path: 'dailybread',
    loadChildren: './modules/daily-bread/daily-bread.module#DailyBreadModule'
  },
  {
    path: 'messages',
    loadChildren: './modules/message/message.module#MessageModule'
  },
  {
    path: 'prayers',
    loadChildren: './modules/prayer/prayer.module#PrayerModule'
  },
  {
    path: 'courses',
    loadChildren: './modules/course/course.module#CourseModule'
  },
  {
    path: 'contacts',
    loadChildren: './modules/contact/contact.module#ContactModule'
  }
];
