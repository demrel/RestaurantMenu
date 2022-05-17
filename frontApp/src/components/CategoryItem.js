import React from 'react';
import {
  Flex,
  Image,
  Text,
  Divider, 
  Button,
  Link 
} from '@chakra-ui/react'

export const CategoryItem = ({ item }) => {
  return (
    <>
    <Flex justifyContent={'space-between'} flexDirection='row' margin={'20px'}>
      <Image height={'80px'} width='80px' src={item?.imageUrl} />
      <Flex flexDirection='column'>
        <Text  fontSize={'30px'}>{item?.name}</Text>
        <Text fontSize={'15px'}>{item?.description}</Text>
      </Flex>
      <Flex flexDirection='column'>
        <Link href={"/category/edit/"+item.id} size='xs' marginBottom={"10px"}>edit</Link>
        <Link href={"/category/delete/"+item.id} size='xs' marginBottom={"10px"}>delete</Link>
      </Flex>
    </Flex>
    <Divider variant={"dashed"} colorScheme='white' />
    </>
  )
}

