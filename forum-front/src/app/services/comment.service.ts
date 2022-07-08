import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Comment } from '../models/comment';


@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  findAllComment(): Observable<Comment[]>{
    return this.http.get<Comment[]>(`https://localhost:7036/api/Comment`);
  }

  findCommentById(id: Number): Observable<Comment> {
    return this.http.get<Comment>(`https://localhost:7036/api/Comment/${id}`);
  }

  CreateComment(comment: Comment): Observable<Comment> {
    return this.http.post<Comment>(`https://localhost:7036/api/Comment`, comment);
  }

  UpdateComment(comment: Comment): Observable<Comment> {
    return this.http.put<Comment>(`https://localhost:7036/api/Comment`, comment);
  }

  DeleteComment(id: Number): Observable<Comment> {
    return this.http.delete<Comment>(`https://localhost:7036/api/Comment/${id}`);
  }
}
