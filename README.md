# genetic-trees

This project is a practice in meditative games and genetics.

Left-click to choose a parent tree. When you have two, left-click on the ground to generate a child of that tree. Right-click to clear parent trees.
Use WASD or arrow keys to move.

The child trees are chosen from prefabs, not generated. The genotype of the parent trees determines the appearance and genotype of the child.

# Tree Genotypes

There are 4 pairs of genes considered in the creation of each tree.

A: "height expression/leaf pigment" - if the tree's C gene is recessive, A decides if the height is short or tall.

B: "leaf color" - decides the color of the leaves, along with gene A.

C: "height abnormality" - decides the tree's height is not medium.

D: "bark color" - decides the bark color.

--

Each gene is a pair, so either member could be dominant or recessive.

AACC, AaCC, aaCC, 
AACc, AaCc, aaCc - 		the tree is medium.

AAcc, Aacc - 			the tree is tall.

aacc - 				the tree is short.


AABB, AABb, AaBB, AaBb - 	the leaves are orange.

AAbb, Aabb -			the leaves are pink.

aaBB, aaBb -			the leaves are purple.

aabb -				the leaves are cyan.

DD -				the bark is pink.

Dd -				the bark is purple.

dd - 				the bark is cyan.
