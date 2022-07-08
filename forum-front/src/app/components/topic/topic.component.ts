import { Component, OnInit } from '@angular/core';
import { Topic } from 'src/app/models/topic';
import { TopicService } from 'src/app/services/topic.service';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})
export class TopicComponent implements OnInit {

  topics: Topic[] = [];

  constructor(private topicService: TopicService) { }

  ngOnInit(): void {
    this.getAllTopics();
  }

  getAllTopics() {
    this.topicService.findAllTopic().subscribe(data => {
      this.topics = data;
      console.log(this.topics);

    })
  }

}
