CREATE TABLE Animal (
    IdAnimal int identity NOT NULL,
    Name nvarchar(100)  NOT NULL,
    Description nvarchar(200)  NULL,
    Category nvarchar(100)  NOT NULL,
    Area nvarchar(500)  NOT NULL,
    CONSTRAINT Animal_pk PRIMARY KEY (IdAnimal)
);

insert into Animal(Name, Description, Category, Area)
values('Kangaroo', 'Marsupial from the family Macropodidae (macropods, meaning "large foot").',
'Macropodidae', 'Australia');
insert into Animal(Name, Description, Category, Area)
values('Domestic yak', 'Long-haired domesticated cattle found throughout the Himalayan region of the Indian subcontinent',
'Bovidae', 'Nepalese');
insert into Animal(Name, Description, Category, Area)
values('Zebu', 'Species or subspecies of domestic cattle originating in South Asia',
'Bovidae', 'South Asia');
insert into Animal(Name, Description, Category, Area)
values('Hariana', 'Native to North India, specially in the state of Haryana',
'Bovidae', 'India');
