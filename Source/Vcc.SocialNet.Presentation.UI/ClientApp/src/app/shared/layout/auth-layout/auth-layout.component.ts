import { Component, OnInit } from '@angular/core';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';

/**
 * Layout component used for pages that are related to user authorization
 * 
 */
@Component({
  selector: 'app-auth-layout',
  templateUrl: './auth-layout.component.html',
  styleUrls: ['./auth-layout.component.scss']
})
export class AuthLayoutComponent implements OnInit {

  /** 
   * Banner image source
   */
  genericBannerUrl : string = null;

  constructor() { 
    this.genericBannerUrl = this.generateBannerUrl();
  }

  ngOnInit() {    
  }

  /**
   * Generates a banner image source selected from a pool of pre-defined banner images
   * @return an ULR of the selected  banner image
   */
  private generateBannerUrl() : string {
    const seq : number = Math.floor(Math.random() * 2) + 1;
    const bannerUrl : string = `../../../../assets/images/church_banner_${seq}.jpg`;
    return bannerUrl;
  }


}
