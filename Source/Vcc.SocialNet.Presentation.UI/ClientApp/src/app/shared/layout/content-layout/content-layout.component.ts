import {MediaMatcher} from '@angular/cdk/layout';
import {ChangeDetectorRef, Component, OnInit, OnDestroy, NgZone} from '@angular/core';
import { SidenavItems, SidenavItemsNoAuth } from './sidenav-items';

const SMALL_WDITH_BREAKPOINT = 600;;
@Component({
  selector: 'app-content-layout',
  templateUrl: './content-layout.component.html',
  styleUrls: ['./content-layout.component.scss']
})
export class ContentLayoutComponent implements OnInit, OnDestroy {
  private mobileQuery: MediaQueryList;
  
  
  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) { 
    // we are using ChangeDetectorRef   
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    // without the following change is not being detected
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnInit() {
  }

  
  get navItems() : string[] {
    let  authenticated : boolean = false;
    if(authenticated) 
      return SidenavItems;
    else
      return SidenavItemsNoAuth;    
  }

  private _mobileQueryListener: () => void;  

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
}