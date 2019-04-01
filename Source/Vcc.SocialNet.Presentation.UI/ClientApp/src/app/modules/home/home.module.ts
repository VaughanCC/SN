import { NgModule } from '@angular/core';
import { HomeComponent } from './pages/home/home.component';
import { HomeRoutingModule } from './home-routing.module';
import { TodaysBreadComponent } from './components/todays-bread/todays-bread.component';
import { PrayerWidgetComponent } from './components/prayer-widget/prayer-widget.component';
import { MessageWidgetComponent } from './components/message-widget/message-widget.component';
import { CourseWidgetComponent } from './components/course-widget/course-widget.component';

/**
 * Home Module
 * 
 * This module package up all components related to the home section. Routing definition for home is defined in {@link HomeRoutingModule}
 */
@NgModule({
    declarations: [
        HomeComponent,
        TodaysBreadComponent,
        PrayerWidgetComponent,
        MessageWidgetComponent,
        CourseWidgetComponent
    ],
    imports: [
        HomeRoutingModule
    ],
    exports: [HomeComponent],
    providers: [],
    entryComponents: [HomeComponent]
})
export class HomeModule {}
