INSERT INTO dbo.EnvironmentalData ([Type], [Value], [TimeStamp], [Location])
VALUES 
    ('Temperature', 25.5, '2024-03-27 10:00:00', 'New York'),
    ('Humidity', 60.2, '2024-03-27 10:00:00', 'New York'),
    ('Temperature', 24.8, '2024-03-27 11:00:00', 'Los Angeles'),
    ('Humidity', 55.6, '2024-03-27 11:00:00', 'Los Angeles');
INSERT INTO dbo.Feedback ([UserId], [Text], [SubmissionDate])
VALUES 
    (1, 'Great website! Really helpful content.', '2024-03-27 09:00:00'),
    (2, 'I found some bugs on the website. Please fix them.', '2024-03-27 10:00:00'),
    (3, 'The website navigation needs improvement.', '2024-03-27 11:00:00');
INSERT INTO dbo.Notification ([UserId], [Message], [Date])
VALUES 
    (1, 'New message from admin.', '2024-03-27 09:00:00'),
    (2, 'Reminder: Event tomorrow at 10 AM.', '2024-03-27 10:00:00'),
    (3, 'Your account has been updated.', '2024-03-27 11:00:00');
INSERT INTO dbo.CleanUpEvent ([Name], [Location], [Date])
VALUES 
    ('Beach Cleanup', 'Ocean Beach', '2024-04-15 09:00:00'),
    ('Park Clean-Up', 'Central Park', '2024-04-20 10:00:00'),
    ('River Cleanup', 'Green River', '2024-04-25 11:00:00');
