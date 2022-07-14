select Guid into @EntityTypeGuid
from Entities.EntityTypes
where Name = 'blogpost';

insert ignore into Taxonomy.Tags
(
    EntityTypeGuid,
    Name,
    IsActive
)
values
(
    @entityTypeGuid,
    'Success',
    1
),
(
    @entityTypeGuid,
    'Connections',
    1
),
(
    @entityTypeGuid,
    'Debate',
    1
),
(
    @entityTypeGuid,
    'Skills',
    0
);