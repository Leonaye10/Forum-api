import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Topic } from '../models/topic';

@Injectable({
  providedIn: 'root'
})
export class TopicService {

  constructor(private http: HttpClient) { }

  findAllTopic(): Observable<Topic[]>{
    return this.http.get<Topic[]>(`https://localhost:7036/api/Topic`);
  }

  findTopicById(id: Number): Observable<Topic> {
    return this.http.get<Topic>(`https://localhost:7036/api/Topic/${id}`);
  }

  CreateTopic(topic: Topic): Observable<Topic> {
    return this.http.post<Topic>(`https://localhost:7036/api/Topic`, topic);
  }

  UpdateTopic(topic: Topic): Observable<Topic> {
    return this.http.put<Topic>(`https://localhost:7036/api/Topic`, topic);
  }

  DeleteTopic(id: Number): Observable<Topic> {
    return this.http.delete<Topic>(`https://localhost:7036/api/Topic/${id}`);
  }

}
