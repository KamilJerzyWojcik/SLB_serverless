import { Component } from '@angular/core';
import { AppServerlessService } from '../../app-serverless.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SLBFrontend';

  constructor(private appServerlessService: AppServerlessService){
  }

  public showValue() {
    this.appServerlessService.getValue().subscribe(
        (x: Response) => {console.log(x)},
        err => console.log(err),
        () => console.log('done loading')
      );
  }
}
