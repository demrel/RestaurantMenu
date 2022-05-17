import React from 'react';
import {
  Box,
  Flex,
  Image,
  Text,
  Tag,
  Divider,
  Link
} from '@chakra-ui/react'

export const MenuItem = ({ item }) => {
  return (
    <Box key={item.Id}>
    <Flex justifyContent={'space-between'} flexDirection='row' margin={'20px'}>
      <Image height={'80px'} width='80px' src={item?.imageUrl} />
      <Flex flexDirection='column'>
        <Text  fontSize={'30px'}>{item?.name}</Text>
        <Text fontSize={'15px'}>{item?.description}</Text>
        <Flex flexDirection='row'>
          {item?.ingridients.map(ingridient => {
            return ( <Tag variant='solid' colorScheme='teal' margin={"5px"}>{ingridient}</Tag> )
          })}
        </Flex>
      </Flex>
      <Box>{item?.price}€</Box>
      <Flex flexDirection='column'>
      <Link href={"/product/edit/"+item.id} size='xs' marginBottom={"10px"}>edit</Link>
       <Link href={"/product/delete/"+item.id} size='xs' marginBottom={"10px"}>delete</Link>
      </Flex>
    </Flex>
    <Divider variant={"dashed"} colorScheme='white' />
    </Box>
  )
}

