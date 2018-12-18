import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-jobapplication-detail',
  templateUrl: './jobapplication-detail.component.html',
  styleUrls: ['./jobapplication-detail.component.css']
})
export class JobapplicationDetailComponent implements OnInit {

  jobapplicationId: string;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.jobapplicationId = this.route.snapshot.paramMap.get('id');
  }

}
