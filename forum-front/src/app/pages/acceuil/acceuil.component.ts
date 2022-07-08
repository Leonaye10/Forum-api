import { Component, OnInit } from '@angular/core';
import { Topic } from 'src/app/models/topic';
import { TopicService } from 'src/app/services/topic.service';

@Component({
  selector: 'app-acceuil',
  templateUrl: './acceuil.component.html',
  styleUrls: ['./acceuil.component.css']
})
export class AcceuilComponent implements OnInit {

  topics: Topic[] = [];

  constructor(
    private topicService: TopicService
  ) {  }

  ngOnInit(): void {
    this.initTopic();
  }

  initTopic = () => {
    this.topicService.findAllTopic().subscribe(data => {
      this.topics = data;
      console.log(this.topics);
      
    })
  }

}
