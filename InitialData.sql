insert ignore into Blog.Posts(Guid, Slug, Title, Summary, TimeToRead, ImageGuid, AcceptsComment, UtcDate, StateId) values
(uuid(), 'how-to-grow', 'How to grow', 'We all want to become better. Let us see how can we achieve this goal.', 3, null, 1, now(), 1),
(uuid(), 'most-wanted-skills', 'Most wanted skills', 'The list of skills that you can learn and rest assured that you can make money from.', 2, null, 0, now(), 2),
(uuid(), '5-ways-to-stay-healthy', '5 ways to stay healthy', 'If you want to change your lifestyle for better health, read these 5 tips.', 5, null, 1, now(), 1);